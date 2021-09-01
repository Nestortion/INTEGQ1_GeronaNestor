using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Product
    {
        private string _name;
        private int _price;
        private int _quantity;

        public string name
        {
            get => _name;
            set => _name = value;
        }
        
        public int price
        {
            get => _price;
            set => _price = value;
        }
        public int quantity
        {
            get => _quantity;
            set => _quantity = value;
        }

        public Product(String name, int price, int quantity)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;

        }
    }
}
