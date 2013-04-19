#region

using April.Entity;
using April.Entity.Base;
using April.EntityImpl.Base;

#endregion

namespace April.EntityImpl
{
    public class Administrator : User, IAdministrator
    {
        #region IAdministrator Members

        public override Role Role
        {
            get { return Role.Administrator; }
        }

        #endregion
    }
}