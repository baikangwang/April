using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using April.Entity;

namespace April.EntityImpl
{
    public class Selection:ISelection
    {
        public virtual IStudent Student { get; set; }
        public virtual ICourse Course { get; set; }
    }
}
