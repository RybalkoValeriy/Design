using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Design.Patterns.Behaviors;
using Design.Patterns.Creational;
using Design.Patterns.Creational.Builder;
using Design.Patterns.Creational.Singleton;

namespace Design
{
    class Program
    {
        static void Main(string[] args)
        {
            var products = new List<Product>
            {
                new Product{Name = "Display", Price = 199},
                new Product{Name = "Keyboard", Price = 199},
                new Product{Name = "Mouse", Price = 199}
            };

            var builder = new ProductReportBuilder(products);
            var director = new ProductReportDirector(builder);
            director.BuildReport();

            var report = builder.GetReport();

            Console.WriteLine(report);

            Console.ReadKey();
        }
    }
}
