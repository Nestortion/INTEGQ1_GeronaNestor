using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class CheckOut
    {

        public static Order order = new Order();

        static public void Payment()
        {
            Console.Clear();
            Console.WriteLine($"User: {DataLayer.SqlData.username}");
            Console.WriteLine($"Credits: {DataLayer.SqlData.credits}");
            Console.WriteLine($"Total price: {order.orderPrice}");

            Console.WriteLine("Press any key to continue");
            
            Console.ReadKey();
            TransactionAndReceipt();


        }
        static void TransactionAndReceipt()
        {

            if (DataLayer.SqlData.UpdateCredits(DataLayer.SqlData.credits - order.orderPrice, DataLayer.SqlData.username))
            {
                Console.WriteLine("Purchase Successful! Thanks for buying");
            }
            else
            {
                Console.WriteLine("Purchase Failed");
            }

        }
        static public bool IfCanCheckOut(int orderQuantity)
        {
            if (orderQuantity==0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
