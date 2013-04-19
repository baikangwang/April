#region

using April.Entity.Base;

#endregion

namespace April.EntityImpl.Base
{
    public abstract class BaseObject : IBaseObject
    {
        #region IBaseObject Members

        public virtual string Name { get; set; }

        #endregion
    }
}