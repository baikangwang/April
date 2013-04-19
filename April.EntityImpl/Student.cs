#region

using System;
using April.Entity;
using April.Entity.Base;
using April.EntityImpl.Base;

#endregion

namespace April.EntityImpl
{
    public class Student : User, IStudent
    {
        #region IStudent Members

        public virtual DateTime Birthday { get; set; }
        public virtual string Address { get; set; }

        public override Role Role
        {
            get { return Role.Student; }
        }

        #endregion
    }
}