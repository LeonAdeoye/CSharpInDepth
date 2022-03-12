using System.Linq.Expressions;

namespace CSharpInDepth
{
    internal class ExpressionTree
    {
        public static void TestMain()
        {
            Expression firstArg = Expression.Constant(2);
            Expression secondArg = Expression.Constant(3);
            Expression add = Expression.Add(firstArg, secondArg);
            Func<int> compiled = Expression.Lambda<Func<int>>(add).Compile();
            Console.WriteLine($"Expression: {add} = { compiled() }");
        }
    }
}
