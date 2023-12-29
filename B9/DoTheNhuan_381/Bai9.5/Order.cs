using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai9._5
{
    public class Order
    {
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;
        private string image;

        public string Image
        {
            get { return image; }
            set { image = value; }
        }



        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Order(string id, string name, string image)
        {
            this.id = id;
            this.name = name;
            this.image = image;
        }

        public Order()
        {
        }
    }
}
