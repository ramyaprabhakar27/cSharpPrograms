using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserNamePwd
{
    class Program
    {
        static void Main(string[] args)
        {
            UserNamePassword NewLogin = new UserNamePassword();
            NewLogin.UserName = "sd";
            NewLogin.PassWord = "Men";
            Console.WriteLine(NewLogin.UserName);
            Console.WriteLine(NewLogin.PassWord);
            Console.ReadLine();
        }
    }
}
