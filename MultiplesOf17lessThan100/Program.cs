using System;

namespace MultiplesOf17lessThan100
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, a;
            Console.WriteLine("Multiples of 17 are:");
            for (i = 1; i < 100; i++)
            {
                a = i % 17;
                if (a == 0)
                {
                    Console.WriteLine(i);
                }
            }
            Console.Read();
        }
    }
}
