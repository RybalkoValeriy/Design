using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design.Patterns.Creational
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

    public class Database
    {
        private Database() { }

        public static Database Instance { get; } = new Database();

    }
}
