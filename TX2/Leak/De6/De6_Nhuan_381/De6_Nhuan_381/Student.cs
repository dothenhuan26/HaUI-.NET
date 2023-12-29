using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De6_Nhuan_381
{
    class Student
    {
        private string _id;
        private DateTime _birthday;
        private string _area;

        public double Score
        {
            get
            {
                if (this._area.Equals("Khu vực 1"))
                {
                    return 0.5;
                }
                else if (this._area.Equals("Khu vực 2"))
                {
                    return 1;
                }
                else
                {
                    return 1.5;
                }
            }
        }
        public string Area
        {
            get { return _area; }
            set { _area = value; }
        }

        public DateTime Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

    }
}
