using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai3
{
    internal class Student
    {
        private string _id;
        private string _name;
        private int _mark;
        private int _scholarship;

        public Student()
        {
        }

        public Student(string id)
        {
            _id = id;
        }

        public Student(string id, string name, int mark)
        {
            _id = id;
            _name = name;
            _mark = mark;
            _scholarship = this._mark > 8 ? 500 : (this._mark < 7 ? 0 : 300);
        }

        public string Id { get { return _id; } set { this._id = value; } }
        public string Name { get { return _name; } set { this._name = value; } }
        public int Mark { get { return _mark; } set { this._mark = value; } }
        public int Scholarship
        {
            get { return _scholarship; }
            set
            {
                if (this.Mark > 8) this._scholarship = 500;
                else if (this.Mark < 7) this._scholarship = 0;
                else this._scholarship = 300;
            }
        }




    }
}
