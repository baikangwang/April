#region

using April.Entity;

#endregion

namespace April.EntityImpl
{
    public class Selection : ISelection
    {
        #region ISelection Members

        public virtual IStudent Student { get; set; }
        public virtual ICourse Course { get; set; }

        #endregion
    }
}