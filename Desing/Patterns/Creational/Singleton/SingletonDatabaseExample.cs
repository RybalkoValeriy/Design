using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MoreLinq;
using NUnit.Framework;
using Autofac;
// trouble with singleton
namespace Design.Patterns.Creational.Singleton
{
    // database contains list capital cities and populatin
    public interface IDatabase
    {
        int GetPopulation(string name);
    }

    public class SingletonDatabase : IDatabase
    {
        private Dictionary<string, int> _capitals;
        private static int instanceCount;
        public static int Count => instanceCount;

        public SingletonDatabase()
        {
            _capitals = File.ReadAllLines(
                    Path.Combine(
                        new FileInfo(typeof(IDatabase).Assembly.Location).DirectoryName,
                        "capitals.txt")
                    )
                .Batch(2)
                .ToDictionary(
                    list => list.ElementAt(0).Trim(),
                    list => int.Parse(list.ElementAt(1)));
        }

        public int GetPopulation(string name)
        {
            return _capitals[name];
        }

        private static Lazy<SingletonDatabase> _instance
            = new Lazy<SingletonDatabase>(() =>
            {
                instanceCount++;
                return new SingletonDatabase();
            });

        public static IDatabase Instance =>
            _instance.Value;
    }

    // finder for sum several population
    // TROUBLE TESTIN THERE 
    // firmly dependent on DataBaseClass and test throuble
    public class SingletonRecordFinder
    {
        public int TotalPopulation(IEnumerable<string> names)
        {
            return names.Sum(name => SingletonDatabase.Instance.GetPopulation(name));
        }
    }

    // create class configuration for loose coupling between dependent in class database
    public class ConfigurableRecordFinder
    {
        private IDatabase database;
        public ConfigurableRecordFinder(IDatabase database)
        {
            this.database = database;
        }

        public int GetTotalPopulation(IEnumerable<string> names)
            => names.Sum(n => database.GetPopulation(n));

    }

    // so we can use fake database class for test
    public class DummyDatabase : IDatabase
    {
        public int GetPopulation(string name)
            => new Dictionary<string, int>
            {
                ["a"] = 1,
                ["b"] = 2,
                ["c"] = 3
            }[name];
    }
    // how will be looking test
    // this fake database can be size - grader available ram
    public class DependentTotalPopulationClass
    {
        [Test]
        public void DependentTotalPopulationTest()
        {
            var db = new DummyDatabase();
            var rf = new ConfigurableRecordFinder(db);
            Assert.That(rf.GetTotalPopulation(new[] { "a", "c" }), Is.EqualTo(4));
        }
    }
    // Singleton and IofC with DI framework Autofac
    class InversionOfControl
    {
        // init container
        readonly ContainerBuilder _builder = new ContainerBuilder();

        public InversionOfControl()
        {
            // build singleInstance
            _builder.RegisterType<SingletonDatabase>().SingleInstance();
            _builder.RegisterType<ConfigurableRecordFinder>();

            var container = _builder.Build();
            var finder = container.Resolve<ConfigurableRecordFinder>();
            var finder2 = container.Resolve<ConfigurableRecordFinder>();

            var IsEquals = ReferenceEquals(finder, finder2);
        }
    }

}
