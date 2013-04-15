using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using April.Entity;

namespace April.EntityImpl
{
    public class Course:ICourse
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual ITeacher Teacher { get; set; }
        public virtual int Hours { get; set; }
        public virtual int Credit { get; set; }
        public virtual int Period { get; set; }
        public virtual string Location { get; set; }
        public virtual int MaxCapacity { get; set; }
    }
}
