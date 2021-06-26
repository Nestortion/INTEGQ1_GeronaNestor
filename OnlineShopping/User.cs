using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace OnlineShopping
{
    class User
    {

        static public void Login()
        {
            Console.Clear();
            int loginTries = 0;
            string password;
            string username;
            while(loginTries < 5)
            {
                Console.Write("Enter Username: ");
                username = Console.ReadLine().ToLower();
                Console.Write("Enter Password: ");
                password = Console.ReadLine().ToLower();

                if (SqlData.VerifyUser(username, password) == true)
                {
                    CheckOut.Payment();
                    loginTries = 10;
                }
                else
                {
                    Console.WriteLine("Wrong Username or Password");
                    Console.WriteLine("Try again in ");
                    loginTries++;
                    for (int i = 3; i > 0; i--)
                    {
                        Console.Write(" .");
                        Thread.Sleep(1000);
                    }
                    Console.Clear();
                }
            }
        }

    }
}
