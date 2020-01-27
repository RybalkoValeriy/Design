using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Design.Patterns.Behaviors;
using Design.Patterns.Creational;

namespace Design
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Database.Instance.GetHashCode());
            Console.WriteLine(Database.Instance.GetHashCode());

            Console.ReadKey();
        }
    }
}
