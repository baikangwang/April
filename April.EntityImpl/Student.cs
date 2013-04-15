using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using April.Entity;

namespace April.EntityImpl
{
    public class Student:User,IStudent
    {
        public virtual DateTime Brithday { get; set; }
        public virtual string Address { get; set; }
    }
}
