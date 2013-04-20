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
                    if (user == null)
                        throw new UserNotFoundException(role);
                    cmd.Commint();
                    return user;
                }
                catch (UserNotFoundException)
                {
                    throw;
                }
                catch
                {
                    cmd.RollBack();
                    throw new UserNotFoundException(role);
                }
            }
        }

        public static IUser Authenticate(string id, string pwd, Role role)
        {
            using (Command cmd = new Command("auth"))
            {
                try
                {
                    IUser user = UserGateway.Authenticate(cmd, id, pwd, role);
                    if (user == null)
                        throw new FailAuthException();
                    cmd.Commint();
                    return user;
                }
                catch (AuthenticationException)
                {
                    throw;
                }
                catch
                {
                    cmd.RollBack();
                    throw new FailAuthException();
                }
            }
        }
    }
}