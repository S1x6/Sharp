using System;
using System.IO;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            var counter = new LineCounter(Directory.GetCurrentDirectory(), args);
            Console.WriteLine(counter.CountLines() + " lines");
            Console.Read();
        }
    }
}
