using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MayToMay.Models
{
    public class Course
    {
        public int id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }//символизируют связб многие
        public Course()
        {
            Students = new List<Student>();

        }
    }
}