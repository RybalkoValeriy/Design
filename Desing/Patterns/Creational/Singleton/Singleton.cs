using System;

namespace Design.Patterns.Creational.Singleton
{
    // use conter for instance !>1
    public class Database2
    {
        private static int instanceCounter = 0;

        public Database2()
        {
            if (++instanceCounter > 1)
                throw new InvalidOperationException("cannot make >1 instance");
        }
    }

    // static ctor run guaranteed per one AppDomain 
    public class DatabaseSingletonClassic
    {
        private DatabaseSingletonClassic() { }

        // public static DatabaseSingletonClassic Instance { get; } = new DatabaseSingletonClassic();

        private static readonly DatabaseSingletonClassic _Instance;

        static DatabaseSingletonClassic()
        {
            _Instance = new DatabaseSingletonClassic();
        }

        public static DatabaseSingletonClassic Instance
        {
            get { return _Instance; }
        }
    }

    // case when you not wand initilize though static ctor...
    // use Lazy<T> .. init object when you first accessed
    // Lazy it is thread-safe approach
    public class DatabaseLazyInit
    {
        private DatabaseLazyInit() { }

        private static Lazy<DatabaseLazyInit> instance = new Lazy<DatabaseLazyInit>(()=>new DatabaseLazyInit());
        public static DatabaseLazyInit Instance
        {
            get
            {
                return instance.Value;
            }
        }
    }
}

