using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpInDepth
{
    class Film
    {
        public string Name { get; set;  }
        public int Year { get; set; }
    }

    internal class Lambda
    {
        public static void TestMain()
        {
            Func<string, int> returnLength = text => text.Length;
            Console.WriteLine($"The string length of Horatio is { returnLength("Horatio") }");

            var films = new List<Film>
            {
                new Film { Name = "Jaws", Year = 1975 },
                new Film { Name = "Singing in the rain", Year = 1952 },
                new Film{ Name = "American Beauty", Year = 1999 },
                new Film{ Name = "High Fidelity", Year = 2000 },
                new Film{ Name = "The Ususal Suspects", Year = 1995 },
                new Film{ Name = "The Wizard Of Oz", Year = 1939 }
            };

            Action<Film> print = film => Console.WriteLine($"Film name: {film.Name} and file year: {film.Year}");

            films.Sort((f1, f2) => f1.Name.CompareTo(f2.Name));
            films.ForEach(print);
            Console.WriteLine("\nOld movies:");
            films.FindAll(film => film.Year < 1960).ForEach(print);
        }
    }
}
