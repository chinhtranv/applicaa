using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DataModel
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Reference { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public bool Selected { get; set; }
    }
}
