namespace CSharpInDepth
{
    interface IDoNothing
    {
        void DoNothing();
    }

    interface IDoSomething
    {
        void DoSomething();
    }
    class SimpleClass : IDoNothing
    {
        private int _value;
        public SimpleClass() => _value = 1;
        public SimpleClass(int value) => _value = value;
        public override String ToString() => _value.ToString();

        public void DoNothing() {}
        public void DoSomething() {}
    }

    internal class ConvertAll
    {
        static double TakeSqaureRoot(int x)
        {
            return Math.Sqrt(x);
        }
        // Type constraint added: T must be a reference type.
        // The first constraint ensures that you can compare references (including NULL) with == and != operators.        
        public static List<T> MakeListFromReferenceType<T>(T first, T second) where T : class
        {
            List<T> list = new();
            list.Add(first);
            list.Add(second);
            return list;
        }

        // Type constraint added: T must be a value type.
        // The first constraint ensures comparisons (including NULL) using == and != operators are prohibited.
        public static List<T> MakeListFromValueType<T>(T first, T second) where T : struct
        {
            List<T> list = new();
            list.Add(first);
            list.Add(second);
            return list;
        }

        // The 
        // The second constraint is constructor type constraint and it ensures the type argument used has a parameterless constructor that can be used to create an instance.
        // Constructor type constraints must be last constraint.
        public static List<T> MakeListFromSimpleClass<T>(T first, T second) where T : class, new()
        {
            List<T> list = new();
            list.Add(first);
            list.Add(second);
            return list;
        }

        public static List<T> MakeListFromOnlySimpleClass<T>(T first, T second) where T : SimpleClass, IDoNothing, IDoSomething
        {
            List<T> list = new();
            list.Add(first);
            list.Add(second);
            return list;
        }

        public static void Main()
        {
            List<int> integers = new();
            List<double> doubles = new();
            
            integers.Add(1);
            integers.Add(2);
            integers.Add(3);
            integers.Add(4);

            Converter<int, double> converter = TakeSqaureRoot;
            doubles = integers.ConvertAll<double>(converter);

            foreach(double value in doubles)
            {
                Console.WriteLine(value);
            }

            List<string> listOfStrings = MakeListFromReferenceType<string>("Horatio", "Harper");
            // The below does not compile because the type argument of MakeListFromValueType method must be a reference type as declared in the type constraint above. 
            // List<int> list = MakeListFromReferenceType<int>(1,2);

            List<int> listOfInts = MakeListFromValueType<int>(1, 2);
            // The below does not compile because the type argument of MakeListFromValueType method must be a value type as declared in the type constraint above. 
            //List<String> list = MakeListFromValueType<string>("Horatio", "Harper");

            List<SimpleClass> listOfSimples = MakeListFromSimpleClass<SimpleClass>(new(1), new(2));
            // The below does not compile because the type argument of MakeListFromSimpleClass method must a type that is declared with parameterless constructor. The String type does not have one.
            //List<String> list = MakeListFromValueType<string>("Horatio", "Harper"); 

            foreach (string x in listOfStrings)
            {
                Console.WriteLine(x);
            }

            foreach (int x in listOfInts)
            {
                Console.WriteLine(x);
            }
        }
    }
}
