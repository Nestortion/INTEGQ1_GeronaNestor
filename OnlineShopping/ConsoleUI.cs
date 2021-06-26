using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace OnlineShopping
{
    class ConsoleUI
    {

        private bool running = true;
        private StringBuilder productName = new StringBuilder("");
        private string category;
        private string brand;
        private int categChoice;
        public static Order order = new Order();

        public string getCategory()
        {
            return this.category;
        }
        public string getBrand()
        {
            return this.brand;
        }
        public ConsoleUI()
        {
            StartMenu();
        }
        public void StartMenu()
        {
            while (running)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Pre Create PC Online Shop");
                Console.WriteLine("Here are the list of products\n");
                Console.WriteLine("#     Category");
                foreach (AvailableProducts s in Enum.GetValues(typeof(AvailableProducts)))
                {
                    Console.WriteLine($"{(int)s}     {s}");
                }


                Console.Write($"\nEnter 1-5 to choose: ");

                switch (Console.ReadLine().ToLower())
                {
                    case "1":
                        SecondMenu(1);
                        running = false;
                        break;
                    case "2":
                        SecondMenu(2);
                        running = false;
                        break;
                    case "3":
                        SecondMenu(3);
                        running = false;
                        break;
                    case "4":
                        SecondMenu(4);
                        running = false;
                        break;
                    case "5":
                        SecondMenu(5);
                        running = false;
                        break;

                    default:
                        Console.WriteLine("\nInvalid choice");
                        Console.Write("Returning in");
                        for (int i = 3; i > 0; i--)
                        {
                            Console.Write(" .");
                            Thread.Sleep(1000);
                        }
                        break;
                }

            }
        }
        public void SecondMenu(int choice)
        {
            categChoice = choice;
            Console.Clear();
            string categ= Enum.GetName(typeof(AvailableProducts), choice);
            Console.WriteLine($"Here are the list of {categ} brands\n");
            Console.WriteLine("     Price  Brand");
            switch (choice)
            {
                case 1:
                    foreach (PowerSupplyBrands p in Enum.GetValues(typeof(PowerSupplyBrands)))
                    {
                        Console.WriteLine($"     ${(int)p}   {p}");
                        category = categ;
                        brand = p.ToString();
                    }
                    break;
                case 2:
                    foreach (MotherboardBrands p in Enum.GetValues(typeof(MotherboardBrands)))
                    {
                        Console.WriteLine($"     ${(int)p}   {p}");
                        category = categ;
                        brand = p.ToString();
                    }
                    break;
                case 3:
                    foreach (ProcessorBrands p in Enum.GetValues(typeof(ProcessorBrands)))
                    {
                        Console.WriteLine($"     ${(int)p}   {p}");
                        category = categ;
                        brand = p.ToString();
                    }
                    break;
                case 4:
                    foreach (RamBrands p in Enum.GetValues(typeof(RamBrands)))
                    {
                        Console.WriteLine($"     ${(int)p}   {p}");
                        category = categ;
                        brand = p.ToString();
                    }
                    break;
                case 5:
                    foreach (StorageBrands p in Enum.GetValues(typeof(StorageBrands)))
                    {
                        Console.WriteLine($"     ${(int)p}   {p}");
                        category = categ;
                        brand = p.ToString();
                        
                    }
                    break;
                default:
                    break;
            }
            Console.WriteLine("\nEnter 1 or 2 to select a brand and proceed to order: ");
            switch (Console.ReadLine().ToLower())
            {
                case "1":
                    OrderMenu(1);
                    break;
                case "2":
                    OrderMenu(2);
                    break;
                case "0":
                    StartMenu();
                    break;
                default:
                    break;
            }
        }
        public void OrderMenu(int choice)
        {
            productName.Clear();
            productName.Append($"{brand} {category}");
            
            Console.Clear();
            Console.WriteLine("Here are the details of this item:\n");
            Console.WriteLine($"Name: {productName}");
            Console.WriteLine($"Price: {SqlData.DisplayPrice(category,brand)}");
            Console.Write("\nEnter 1 to add to cart or 2 to buy now: ");
            switch (Console.ReadLine().ToLower())
            {
                case "1":
                    AddToCart();
                    break;
                case "2":
                    OrderMenu(2);
                    break;
                case "0":
                    SecondMenu(categChoice);
                    break;
                default:
                    break;
            }
        }
        public void AddToCart()
        {
            bool running = true;
            Console.WriteLine("Enter Product Quantity: ");
            var quantity = Console.ReadLine();
            order.AddOrderItem(new Product(productName.ToString(), SqlData.DisplayPrice(category, brand), Convert.ToInt32(quantity)));
            do
            {
                Console.Clear();
                order.DisplayCart();


                Console.WriteLine("Enter 1 to check out or 2 to add another product or 3 to delete a product: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        running = false;
                        User.Login();
                        break;
                    case "2":
                        running = false;
                        StartMenu();
                        break;
                    case "3":
                        Console.WriteLine("Enter the product name to delete: ");
                        string name = Console.ReadLine().ToLower();
                        order.DeleteOrderItem(name);
                        break;

                    default:
                        Console.WriteLine("Error Try again in ");
                        for (int i = 3; i > 0; i--)
                        {
                            Console.Write(" .");
                            Thread.Sleep(1000);
                        }
                        break;
                }
            } while (running);
            
        }
        
        
        
        
        
    }
    
}
