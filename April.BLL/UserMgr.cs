#region

using System;
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
                    return user;
                }
                catch
                {
                    return null;
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
                        throw new NotFoundBaseObjException(role.ToLabel(),id);
                    return user;
                }
                catch (NotFoundBaseObjException)
                {
                    throw;
                }
                catch
                {
                    throw new NotFoundBaseObjException(role.ToLabel(), id);
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
                    return list;
                }
                catch
                {
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
                    throw new InsertBaseObjException(role.ToLabel(), Convert.ToString(values["Id"]));
                }
                catch (InsertBaseObjException)
                {
                    throw;
                }
                catch
                {
                    cmd.RollBack();
                    throw new InsertBaseObjException(role.ToLabel(), Convert.ToString(values["Id"]));
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
                    throw new UpdateBaseObjException(role.ToLabel(), Convert.ToString(values["Id"]));
                }
                catch (UpdateBaseObjException)
                {
                    throw;
                }
                catch
                {
                    cmd.RollBack();
                    throw new UpdateBaseObjException(role.ToLabel(), Convert.ToString(values["Id"]));
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
                        throw new DeleteBaseObjException(role.ToLabel(), id);
                    cmd.Commint();
                    return true;
                }
                catch (DeleteBaseObjException)
                {
                    cmd.RollBack();
                    throw;
                }
                catch
                {
                    cmd.RollBack();
                    throw new DeleteBaseObjException(role.ToLabel(), id);
                }
            }
        }

        public static bool IsExisting(Role role, string id)
        {
            using (Command cmd = new Command("Get"))
            {
                try
                {
                    IUser user = UserGateway.Get(cmd, id, role);
                    return user != null;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}