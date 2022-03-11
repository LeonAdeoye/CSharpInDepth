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
            else // The null value of a nullable type is the value where HasValue returns false.
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

            // Nullable<T> is a struct - a value type. If you want to convert it to a reference type then you need to box it.
            Nullable<int> x;
            Nullable<int> p;
            Nullable<int>  w = new Nullable<int>();
            Nullable<int>  u = new Nullable<int>(5);

            // Null coalescing operator. If w is non-null then the result becomes the result of the whole expression.
            p = w ?? u;
            
            x = new Nullable<int>();
            if(x.Equals(null))
            {
                Console.WriteLine("A nullable without a value and a NULL are equal!");
            }
            
            object y = x;
            if (x.Equals(y))
            {
                Console.WriteLine("A boxed nullable without a value and a nullable without a value are equal!");
            }

            if (y == null)
            {
                Console.WriteLine("A Nullable value boxed to a reference type will have a value of null because its HasValue is false.");
                x = (int?) y;

                try
                {                    
                    int z = (int) y; // If you try to unbox a reference type that is null into the non-nullable normal type (int) of a Nullable type then an exception is thrown.
                }
                catch(System.NullReferenceException nre)
                {
                    Console.WriteLine("Exception thrown because: " + nre.Message);
                }
            }
        }

    }
}
