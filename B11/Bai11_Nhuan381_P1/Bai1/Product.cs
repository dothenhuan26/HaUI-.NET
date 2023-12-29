using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1
{
    internal class Product
    {
        public int ID { set; get; }
        public string Name { set; get; } // tên
        public double Price { set; get; } // giá
        public string[] Colors { set; get; } // các màu
        public int Brand { set; get; }

        public Product(int id, string name, double price, string[] colors, int brand)
        {
            ID = id;
            Name = name;
            Price = price;
            Colors = colors;
            Brand = brand;
        }

        override public string ToString() => $"{ID,3} {Name,12} {Price,5} {Brand,2} {string.Join(",", Colors)}";


    }
}
