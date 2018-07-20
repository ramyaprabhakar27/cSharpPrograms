using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserNamePwd
{
    class UserNamePassword
    {
        private string Username;
        private string Pwd;

        public UserNamePassword()
        {

        }

        public UserNamePassword(string username, string password)
        {
            UserName = username;
            PassWord = password;
        }

        public string UserName
        {
            get
            {
                return Username;
            }
            set
            {
                if (value.Length >= 4 && value.Length <= 10)
                {
                    Username = value;
                }
                else
                {
                    Console.WriteLine("Opps, Please use Username within 4 to 10 Characters");
                }
            }
        }

        public string PassWord
        {
            get
            {
                return Pwd;
            }
            set
            {
                if (value.Length >= 4 && value.Length <= 10)
                {
                    Pwd = value;
                }
                else
                {
                    Console.WriteLine("Opps, Please use Password within 4 to 10 Characters");
                }
            }
        }


    }
}
