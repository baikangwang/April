#region

using System.Collections.Generic;
using April.Entity.Base;
using April.EntityImpl.Base;

#endregion

namespace April.Core.Definition
{
    public static class Administrator
    {
        public static IProperty Id = new Property("Id", "工号", typeof (string), 0);
        public static IProperty Name = new Property("Name", "姓名", typeof (string), 1);
        public static IProperty Gender = new Property("Gender", "性别", typeof (int), 2);
        public static IProperty ContactNo = new Property("ContactNo", "电话", typeof (string), 3);
        public static IProperty Password = new Property("Password", "密码", typeof (string), 4);
        public static string Table = "Administrator";
        public static string Entity = "Administrator";
        public static IList<IProperty> Properties = new List<IProperty> {Id, Name, Gender, ContactNo, Password};
    }
}