using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping
{
    class CheckOut
    {
        static public string username;
        static public int credits;


        static public void Payment()
        {
            Console.Clear();
            Console.WriteLine($"User: {username}");
            Console.WriteLine($"Credits: {credits}");
            Console.WriteLine($"Total price: {ConsoleUI.order.orderPrice}");

            Console.WriteLine("Press any key to continue");
            
            Console.ReadKey();
            TransactionAndReceipt();


        }
        static void TransactionAndReceipt()
        {

            if (SqlData.UpdateCredits(credits - ConsoleUI.order.orderPrice, username))
            {
                Console.WriteLine("Purchase Successful! Thanks for buying");
            }
            else
            {
                Console.WriteLine("Purchase Failed");
            }

        }
    }
}
