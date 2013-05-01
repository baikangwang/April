#region

using April.Entity;
using April.EntityImpl.Base;

#endregion

namespace April.EntityImpl
{
    public class Selection :BaseObject, ISelection
    {
        #region ISelection Members

        public virtual IStudent Student { get; set; }
        public virtual ICourse Course { get; set; }
        public virtual int? Score { get; set; }


        #endregion
    }
}