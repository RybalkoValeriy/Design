using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Design.Patterns.Behaviors;
using Design.Patterns.Creational;
using Design.Patterns.Creational.Singleton;

namespace Design
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                SingletonDatabase.Instance.GetPopulation("Kiev")
                );
            Console.ReadKey();
        }
    }
}
