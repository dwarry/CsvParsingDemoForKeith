using System;
using System.IO;

namespace CsvParsingDemo_Core
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = File.OpenText("fred.csv"))
            {
                foreach (var p in Person.ReadAllFrom(reader))
                {
                    Console.WriteLine(p);
                }
            }

        }
    }
}