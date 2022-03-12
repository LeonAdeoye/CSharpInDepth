using System;
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
        // The first parameter is called the extended type of the method, and say that the method extends the type.
        public static void TestMain()
        {
            string family = "Leon Horatio Harper Saori";
            Console.WriteLine($"The sentence: '{family}' has {family.WordCount(' ')} words");
        }
    }
}
