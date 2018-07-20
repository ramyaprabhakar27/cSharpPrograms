using System;

namespace UpperCasetoLowerCase
{
    class Program
    {
        static void Main(string[] args)
        {
            String Str;
            Console.WriteLine("Enter a String in UPPER case");
            Str = Console.ReadLine();
            Console.WriteLine("String in Lowercase is \n" + Str.ToLower());
            Console.ReadLine();
        }
    }
}
