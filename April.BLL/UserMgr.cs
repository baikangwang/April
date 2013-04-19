#region

using April.Core;
using April.DAL;
using April.Entity;
using April.Entity.Base;
using April.Entity.Exception;

#endregion

namespace April.BLL
{
    public class UserMgr
    {
        public static IUser Init(string id, Role role)
        {
            using (Command cmd = new Command("init"))
            {
                try
                {
                    IUser user = UserGateway.Get(cmd, id, role);
                    cmd.Commint();
                    return user;
                }
                catch
                {
                    cmd.RollBack();
                    throw new UserNotFoundException(role);
                }
            }
        }
    }
}