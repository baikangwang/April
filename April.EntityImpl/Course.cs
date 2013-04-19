#region

using April.Entity;
using April.EntityImpl.Base;

#endregion

namespace April.EntityImpl
{
    public class Course : BaseObject, ICourse
    {
        #region ICourse Members

        public virtual int Id { get; set; }
        public virtual ITeacher Teacher { get; set; }
        public virtual int Hours { get; set; }
        public virtual int Credit { get; set; }
        public virtual int Period { get; set; }
        public virtual string Location { get; set; }
        public virtual int MaxCapacity { get; set; }

        #endregion
    }
}