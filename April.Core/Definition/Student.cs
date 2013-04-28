#region

using System;
using System.Collections.Generic;
using April.Entity.Base;
using April.EntityImpl.Base;

#endregion

namespace April.Core.Definition
{
    public static class Student
    {
        public static IProperty Id = new Property("Id", "学号", typeof (string), 0);
        public static IProperty Name = new Property("Name", "姓名", typeof (string), 1);
        public static IProperty Gender = new Property("Gender", "性别", typeof (int), 2);
        public static IProperty Grade = new Property("Grade", "年级", typeof(string), 3);
        public static IProperty ContactNo = new Property("ContactNo", "电话", typeof(string), 4);
        public static IProperty Birthday = new Property("Birthday", "出生年月", typeof (DateTime), 5);
        public static IProperty Address = new Property("Address", "地址", typeof (string), 6);
        public static IProperty Password = new Property("Password", "密码", typeof (string), 7);
        public static string Table = "Student";
        public static string Entity = "Student";
        public static string Label = "学生";

        public static IList<IProperty> Properties = new List<IProperty>
                                                        {Id, Name, Gender,Grade, ContactNo, Birthday, Address, Password};
    }
}