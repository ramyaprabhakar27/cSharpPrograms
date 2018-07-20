using System;

namespace ReverseNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int num, rev = 0;
            Console.WriteLine("Enter a number:");
            num = int.Parse(Console.ReadLine());
            while (num != 0)
            {
                rev = rev * 10;
                rev = rev + num % 10;
                num = num / 10;
            }
            Console.WriteLine("Reverse of entered number is : " + rev);
            Console.ReadLine();
        }
    }
}
