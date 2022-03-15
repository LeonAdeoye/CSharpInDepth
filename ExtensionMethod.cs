namespace CSharpInDepth
{
    public static class ExtensionMethod
    {
        public static int WordCount(this string input, char splitter)
        {
            return input.Split(new char[] { splitter }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        // Optional Parameters
        public static void OptionalParams(int x, int y = 0, DateTime? timeStamp = null, string child = "Horatio")
        {
            // Use of null coalescing operator to set default.
            var realTimestamp = timeStamp ?? DateTime.Now;
            Console.WriteLine($"Optional parameterization => x: {x}, timestamp:{realTimestamp}, child: {child}");
        }

        private async static Task CatchMultipleExceptions()
        {
            try
            {
                Task task2 = Task.Run(() => { Console.WriteLine("Executing task 2"); });
                Task task1 = Task.Run(() => { throw new ArgumentNullException("Message 1"); });
                await Task.WhenAny(task1, task2);
            }
            catch (AggregateException ae)
            {
                Console.WriteLine(ae.ToString() + "inner exception count: " + ae.InnerExceptions.Count);
            }
        }

        // Extension methods are created in a static class.
        // It must have at least one parameter, this parameter must be prefixed with 'this', and it cannot have any modifiers like out or ref.
        // The first parameter is called the extended type of the method, and we say that the method extends the type.
        public static async Task TestMainAsync()
        {
            await CatchMultipleExceptions();

            var family = "Leon Horatio Harper Saori";
            Console.WriteLine($"The sentence: '{family}' has {family.WordCount(' ')} words");

            OptionalParams(x: 5, child: "Harper");

            var words = from element in family.Split(' ')
                        select element;

            foreach(var word in words)
            {
                Console.WriteLine(word);
            }

            var list = new List<object> { 1, "not a int", 2, 3 , 4, 5, 6};
            
            // Using multiple WHERE clauses results in multiple chained where calls - only elements that match all of the predicates are part of the resulting sequence.
            var result = from item in list.OfType<int>()
                         where (item % 2) == 0
                         where item > 2
                         let sqr = (item * item) // Introduces a new range variable.
                         select new { Num = item, SqrOfNum = sqr }; // Anonymous type.

            foreach (var x in result)
            {
                Console.WriteLine(x);
            }

            // Does a test first on the type of each element before casting to target type and skips any element that fails the test. No exceptions are thrown.
            var ints = list.OfType<int>();
            foreach(var x in ints)
            {
                Console.WriteLine(x);
            }

            try
            {
                // Casts each element to target type but throws an exception on any element that isn't the right type.
                var ints2 = list.Cast<int>();
                foreach (var x in ints2)
                {
                    Console.WriteLine(x);
                }
            }
            catch(InvalidCastException ice)
            {
                Console.WriteLine(ice.Message);
            }
        }
    }
}
