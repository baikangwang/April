#region

using April.Entity;
using April.Entity.Base;
using April.EntityImpl.Base;

#endregion

namespace April.EntityImpl
{
    public class Teacher : User, ITeacher
    {
        #region ITeacher Members

        public virtual string Title { get; set; }

        public override Role Role
        {
            get { return Role.Teacher; }
        }

        #endregion
    }
}