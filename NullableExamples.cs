using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpInDepth
{
    internal class NullableExamples
    {
        public static void TestMain()
        {
            int? hasValue = 5;
            int? hasNoValue = null;

            if(hasValue.HasValue)
            {
                Console.WriteLine("Has a value of: " + hasValue.Value);
            }
            else
            {
                Console.WriteLine("Has no value so the default value is default value of the underlying int type: " + hasNoValue.GetValueOrDefault());
            }

            try
            {
                Console.WriteLine(hasNoValue.Value);
            }
            catch (InvalidOperationException ioe)
            {
                Console.WriteLine("Exception thrown because: " + ioe.Message);
            }

            if (hasNoValue.HasValue)
            {
                Console.WriteLine("Has a value of: " + hasNoValue.Value);
            }
            else
            {
                Console.WriteLine($"Has no value so you can either set a default value: {hasNoValue.GetValueOrDefault(10)}, or you can use the default value of the underlying type: {hasNoValue.GetValueOrDefault()}");
            }

            Nullable<int> x;
            x = new Nullable<int>(5);
            x = new Nullable<int>();
        }

    }
}
