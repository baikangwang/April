using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using April.Entity;
using April.Entity.Base;

namespace April.EntityImpl
{
    public abstract class User:IUser
    {
        public virtual string Name { get; set; }
        public virtual string Id { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual string ContactNo { get; set; }
    }
}
