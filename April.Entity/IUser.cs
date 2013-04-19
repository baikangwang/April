#region

using System.Security.Principal;
using April.Entity.Base;

#endregion

namespace April.Entity
{
    public interface IUser : IPrincipal, IBaseObject
    {
        string Id { get; set; }
        Gender Gender { get; set; }
        string ContactNo { get; set; }
        Role Role { get; }
    }
}