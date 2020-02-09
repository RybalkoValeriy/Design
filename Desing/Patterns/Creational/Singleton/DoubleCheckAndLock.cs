namespace Design.Patterns.Creational.Singleton
{
    // this implement with threadsafe and lazy
    // about this 
    // create instance it is not atomic operation:
    //      -   alloc memory in heap
    //      -   create object call ctor
    //      -   init field _instance

    // benefits
    // avaliable for any version .net frameworks
    public class DoubleCheckAndLock
    {
        private static volatile DoubleCheckAndLock _instance;
        private static readonly object _syncRoot = new object();

        private DoubleCheckAndLock()
        {
        }

        public static DoubleCheckAndLock GetInstance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new DoubleCheckAndLock();
                        }
                    }
                }

                return _instance;
            }
        }
    }
}