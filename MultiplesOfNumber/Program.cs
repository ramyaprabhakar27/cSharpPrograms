using System;

namespace MultiplesOfNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, n;
            Console.WriteLine("Enter a number");
            n = int.Parse(Console.ReadLine());
            for (i = 1; i <= 10; i++)
            {
                Console.WriteLine("\n" + n + " * " + i + " = " + n * i);
            }
            Console.ReadLine();
        }
    }
}
