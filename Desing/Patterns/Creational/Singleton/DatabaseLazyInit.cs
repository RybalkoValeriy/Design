using System;

namespace Design.Patterns.Creational.Singleton
{

    // case when you not wand initilize though static ctor...
    // use Lazy<T> .. init object when you first accessed
    // Lazy it is thread-safe approach
    // restrict .net 4.0
    public class DatabaseLazyInit
    {
        private DatabaseLazyInit() { }

        private static Lazy<DatabaseLazyInit> instance =
            new Lazy<DatabaseLazyInit>(() => new DatabaseLazyInit());
        public static DatabaseLazyInit Instance => instance.Value;
    }


}