using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpInDepth
{
    public static class ExtensionMethod
    {
        public static int WordCount(this string input, char splitter)
        {
            return input.Split(new char[] { splitter }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        // Extension methods are created in a static class.
        // It must have at least one parameter, this parameter must be prefixed with 'this', and it cannot have any modifiers like out or ref.
        // The first parameter is called the extended type of the method, and we say that the method extends the type.
        public static void TestMain()
        {
            string family = "Leon Horatio Harper Saori";
            Console.WriteLine($"The sentence: '{family}' has {family.WordCount(' ')} words");


            var words = from element in family.Split(' ')
                        select element;

            foreach(var word in words)
            {
                Console.WriteLine(word);
            }

            ArrayList list = new ArrayList { 1, "not a int", 2, 3 , 4, 5, 6};
            
            // Using multiple WHERE clauses results in multiple chained where calls - only elements that match all of the predicates are part of the resulting sequence.
            var result = from item in list.OfType<int>()
                         where (item % 2) == 0
                         where item > 2
                         select item;

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
