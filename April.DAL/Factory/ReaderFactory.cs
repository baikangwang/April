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
                    if (p.PropertyType == typeof(ITeacher))
                    {
                        index = reader.GetOrdinal("Teacher_Id");
                        using (Command cmd = new Command("init_Teacher"))
                        {
                            try
                            {
                                string id = Convert.ToString(reader.GetValue(index));
                                value = UserGateway.Get(cmd, id, Role.Teacher) as ITeacher;
                            }
                            catch
                            {
                                value = null;
                            }
                        }
                    }
                    else if (p.PropertyType == typeof(ICourse))
                    {
                        index = reader.GetOrdinal("Course_Id");
                        using (Command cmd = new Command("init_Course"))
                        {
                            try
                            {
                                string id = Convert.ToString(reader.GetValue(index));
                                value = CourseGateway.Get(cmd, id);
                            }
                            catch
                            {
                                value = null;
                            }
                        }
                    }
                    else if (p.PropertyType == typeof(IStudent))
                    {
                        index = reader.GetOrdinal("Student_Id");
                        using (Command cmd = new Command("init_Student"))
                        {
                            try
                            {
                                string id = Convert.ToString(reader.GetValue(index));
                                value = UserGateway.Get(cmd, id, Role.Student) as IStudent;
                            }
                            catch
                            {
                                value = null;
                            }
                        }
                    }
                    else 
                    {
                        index = reader.GetOrdinal(p.Name);
                        value = reader.GetValue(index);
                        value = value is DBNull ? null : value;
                    }

                    p.SetValue(obj, value, null);
                }
                catch
                {
                    continue;
                }
            }

            return obj as IBaseObject;
        }
    }
}