#region

using April.Entity.Base;

#endregion

namespace April.EntityImpl.Base
{
    public abstract class BaseObject : IBaseObject
    {
        #region IBaseObject Members

        public string Id { get; set; }
        public virtual string Name { get; set; }

        #endregion
    }
}