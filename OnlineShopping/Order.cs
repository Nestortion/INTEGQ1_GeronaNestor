using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping
{
    enum AvailableProducts
    {
        PowerSupply = 1,
        MotherBoard,
        Processor,
        Ram,
        Storage
    }
    enum PowerSupplyBrands
    {
        //The values here will be the price
        Corsair = 100,
        Seasonic = 130
    }
    enum ProcessorBrands
    {
        //The values here will be the price
        Intel = 500,
        AMD = 450
    }
    enum MotherboardBrands
    {
        //The values here will be the price
        Gigabyte = 320,
        Asus = 300
    }
    enum RamBrands
    {
        //The values here will be the price
        Kingston = 40,
        Corsair = 50
    }
    enum StorageBrands
    {
        //The values here will be the price
        WD = 100,
        Seagate = 110
    }
    class Order
    {
        private List<Product> orderProductList = new List<Product>();
        private int _orderTotal = 0;
        private int _orderPrice = 0;
        
        public int orderTotal
        {
            get => _orderTotal;
            set => _orderTotal = value;
        }
        public int orderPrice
        {
            get => _orderPrice;
            set => _orderPrice = value;
        }



        public void AddOrderItem(Product item)
        {
            orderProductList.Add(item);
        }
        
        public void DeleteOrderItem(string itemName)
        {
            foreach (Product p in orderProductList.ToList())
            {
                if (p.name == itemName)
                {
                    if (orderProductList.Remove(p) == true)
                    {
                        Console.WriteLine("Item deleted");
                    }
                    else
                    {
                        Console.WriteLine("Item does not exist");
                    }
                }
            }
            
        }
        public int GetTotalQuantity()
        {
            return orderTotal;
        }

        public void DisplayCart()
        {
            
                Console.WriteLine("Quantity       Name                  Price");
                foreach (Product product in orderProductList.ToList())
                {
                    if (product.quantity.ToString().Length < 16)
                    {
                        Console.Write($"{product.quantity}");
                        for (int i = 1; i < 16 - product.quantity.ToString().Length; i++)
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.Write(product.name);
                    if (product.name.ToString().Length < 23)
                    {
                        for (int i = 1; i < 23 - product.name.ToString().Length; i++)
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine(product.price);
                }
                ComputeTotalPrice(ConsoleUI.order.orderProductList);
                Console.WriteLine($"Total price: {orderPrice}");
        }
        private void ComputeTotalPrice(List<Product> orderList)
        {
            orderPrice = 0;
            foreach (Product q in orderList)
            {
                orderPrice += q.price * q.quantity;
            }
        }
       

    }
}
