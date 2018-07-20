using System;

namespace Swap2numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b, c;
            Console.WriteLine("Enter first number");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter second number");
            b = int.Parse(Console.ReadLine());
            c = a;
            a = b;
            b = c;
            Console.WriteLine("After Swapping the Numbers are:\n");
            Console.WriteLine("First Number = " + a);
            Console.WriteLine("First Number = " + b);
            Console.ReadLine();
        }
    }
}
