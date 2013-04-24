#region

using System.Security.Principal;
using April.Entity.Base;

#endregion

namespace April.Entity
{
    public interface IUser : IPrincipal, IBaseObject
    {
        Gender Gender { get; set; }
        string ContactNo { get; set; }
        Role Role { get; }
    }
}