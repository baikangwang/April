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
            Type type = entityImpl.GetType(entity);

            object obj = entityImpl.CreateInstance(entity);

            foreach (PropertyInfo property in type.GetProperties(BindingFlags.Public))
            {
                int index = reader.GetOrdinal(property.Name);
                property.SetValue(obj, reader.GetValue(index), null);
            }

            return obj as IBaseObject;
        }
    }
}