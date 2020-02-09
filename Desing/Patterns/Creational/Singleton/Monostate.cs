namespace Design.Patterns.Creational.Singleton
{

    // MONOSTATE - it is simple class that behaves like a Singleton
    // all exemplars these classes working with the same static field
    public class ChiefExecutiveOfficer
    {
        private static string name;
        private static int age;

        public string Name
        {
            get => name;
            set => name = value;
        }

        public int Age
        {
            get => age;
            set => age = value;
        }
    }
}
