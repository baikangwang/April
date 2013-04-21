#region

using System.Collections.Generic;
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
            using (Command cmd = new Command("init_" + role.ToEntity()))
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
                    cmd.RollBack();
                    throw;
                }
                catch
                {
                    cmd.RollBack();
                    throw new UserNotFoundException(role);
                }
            }
        }

        public static IUser Get(string id, Role role)
        {
            using (Command cmd = new Command("get_" + role.ToEntity()))
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
                    cmd.RollBack();
                    throw;
                }
                catch
                {
                    cmd.RollBack();
                    throw new UserNotFoundException(role);
                }
            }
        }

        public static IList<IUser> List(Role role)
        {
            using (Command cmd = new Command("list_" + role.ToEntity()))
            {
                try
                {
                    IList<IUser> list = UserGateway.List(cmd, role);
                    cmd.Commint();
                    return list;
                }
                catch
                {
                    cmd.RollBack();
                    return new List<IUser>();
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
                    cmd.RollBack();
                    throw;
                }
                catch
                {
                    cmd.RollBack();
                    throw new FailAuthException();
                }
            }
        }

        public static bool Insert(Role role, IDictionary<string, object> values)
        {
            using (Command cmd = new Command("insert_" + role.ToEntity()))
            {
                try
                {
                    if (UserGateway.Insert(cmd, role, values))
                    {
                        cmd.Commint();
                        return true;
                    }
                    cmd.RollBack();
                    throw new UserInsertedException(role);
                }
                catch (UserInsertedException)
                {
                    throw;
                }
                catch
                {
                    cmd.RollBack();
                    throw new UserInsertedException(role);
                }
            }
        }

        public static bool Update(Role role, IDictionary<string, object> values)
        {
            using (Command cmd = new Command("update_" + role.ToEntity()))
            {
                try
                {
                    if (UserGateway.Update(cmd, role, values))
                    {
                        cmd.Commint();
                        return true;
                    }
                    cmd.RollBack();
                    throw new UserUpdatedException(role);
                }
                catch (UserUpdatedException)
                {
                    throw;
                }
                catch
                {
                    cmd.RollBack();
                    throw new UserUpdatedException(role);
                }
            }
        }

        public static bool Delete(Role role, string id)
        {
            using (Command cmd = new Command("delete_" + role.ToEntity()))
            {
                try
                {
                    bool result = UserGateway.Delete(cmd, role, id);
                    if (!result)
                        throw new UserDeleteException(role);
                    cmd.Commint();
                    return true;
                }
                catch (UserDeleteException)
                {
                    cmd.RollBack();
                    throw;
                }
                catch
                {
                    cmd.RollBack();
                    throw new UserDeleteException(role);
                }
            }
        }
    }
}