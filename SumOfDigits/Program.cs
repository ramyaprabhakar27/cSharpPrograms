using System;

namespace SumOfDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            int num, rem, sum = 0;
            Console.WriteLine("Enter a number:");
            num = int.Parse(Console.ReadLine());
            while (num != 0)
            {
                rem = num % 10;
                num = num / 10;
                sum = sum + rem;
            }
            Console.WriteLine("Sum of all the digits in a number is : " + sum);
            Console.ReadLine();
        }
    }
}
