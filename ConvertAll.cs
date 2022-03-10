namespace CSharpInDepth
{
    internal class ConvertAll
    {
        static double TakeSqaureRoot(int x)
        {
            return Math.Sqrt(x);
        }
        public static List<T> MakeList<T>(T first, T second)
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

            List<string> list = MakeList<string>("Horatio", "Harper");

            foreach (string x in list)
            {
                Console.WriteLine(x);
            }
        }
    }
}
