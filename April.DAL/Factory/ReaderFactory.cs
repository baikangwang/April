#region

using System;
using System.Data.SqlClient;
using System.Reflection;
using April.Entity.Base;
using April.EntityImpl.Base;

#endregion

namespace April.DAL.Factory
{
    public class ReaderFactory
    {
        public static IBaseObject Reader(SqlDataReader reader, string entity)
        {
            if (!reader.Read()) return null;

            Assembly entityImpl = Assembly.GetAssembly(typeof (BaseObject));

            string entityName = entityImpl.FullName.Substring(0, entityImpl.FullName.IndexOf(",")).Trim() + "." + entity;
            Type type = entityImpl.GetType(entityName);

            object obj = entityImpl.CreateInstance(entityName);

            foreach (PropertyInfo property in type.GetProperties())
            {
                try
                {
                    int index = reader.GetOrdinal(property.Name);

                    property.SetValue(obj, reader.GetValue(index), null);
                }
                catch
                {
                    continue;
                }
            }
            reader.Close();

            return obj as IBaseObject;
        }
    }
}