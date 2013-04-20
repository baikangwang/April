#region

using System.Security.Principal;
using April.Entity;
using April.Entity.Base;

#endregion

namespace April.EntityImpl.Base
{
    public abstract class User : BaseObject, IUser
    {
        #region IUser Members

        public virtual string Id { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual string ContactNo { get; set; }
        public virtual Role Role { get; private set; }

        public virtual bool IsInRole(string role)
        {
            return false;
        }

        public virtual IIdentity Identity
        {
            get { return new GenericIdentity(Id);}
        }

        #endregion
    }
}