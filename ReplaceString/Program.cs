using System;

namespace ReplaceString
{
    class Program
    {
        static void Main(string[] args)
        {
            String Str = "Sun Rises in West";
            Console.WriteLine("String Before Replace:\n" + Str);
            Str.Replace("West", "East");
            Console.WriteLine("String After Replace:\n" + Str);
            Console.ReadLine();
        }
    }
}
