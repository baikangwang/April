using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using April.Entity;

namespace April.EntityImpl
{
    public class Teacher:User,ITeacher
    {
        public virtual string Title { get; set; }
    }
}
