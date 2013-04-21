#region

using System;
using System.Data.SqlClient;
using System.Reflection;
using April.Core;
using April.Entity;
using April.Entity.Base;
using April.EntityImpl.Base;

#endregion

namespace April.DAL.Factory
{
    public class ReaderFactory
    {
        public static IBaseObject Reader(SqlDataReader reader, string entity)
        {
            Assembly entityImpl = Assembly.GetAssembly(typeof (BaseObject));

            string entityName = entityImpl.FullName.Substring(0, entityImpl.FullName.IndexOf(",")).Trim() + "." + entity;
            Type type = entityImpl.GetType(entityName);

            object obj = entityImpl.CreateInstance(entityName);

            foreach (PropertyInfo p in type.GetProperties())
            {
                try
                {
                    int index;
                    object value;
                    if (p.DeclaringType != null && p.DeclaringType.IsInterface && p.DeclaringType == typeof (ITeacher))
                    {
                        index = reader.GetOrdinal("Teacher_Id");
                        using (Command cmd = new Command("init_teacher"))
                        {
                            try
                            {
                                string id = Convert.ToString(reader.GetValue(index));
                                value = UserGateway.Get(cmd, id, Role.Teacher) as ITeacher;
                                cmd.Commint();
                            }
                            catch
                            {
                                cmd.RollBack();
                                value = null;
                            }
                        }
                    }
                    else
                    {
                        index = reader.GetOrdinal(p.Name);
                        value = reader.GetValue(index);
                    }

                    p.SetValue(obj, value, null);
                }
                catch
                {
                }
            }

            return obj as IBaseObject;
        }
    }
}