#region

using System.Collections.Generic;
using April.Entity.Base;
using April.EntityImpl.Base;

#endregion

namespace April.Core.Definition
{
    public static class Course
    {
        public static IProperty Id = new Property("Id", "编号", typeof (int), 0, false, false);
        public static IProperty Name = new Property("Name", "课程名", typeof (string), 1);
        public static IProperty Teacher = new Property("Teacher", "教师名", typeof (string), 2);
        public static IProperty Hours = new Property("Hours", "课内学时", typeof (int), 3);
        public static IProperty Credit = new Property("Credit", "学分", typeof (int), 4);
        public static IProperty Period = new Property("Period", "总学时", typeof (int), 5);
        public static IProperty Location = new Property("Location", "开课学院", typeof (string), 6);
        public static IProperty MaxCapacity = new Property("MaxCapacity", "最大人数", typeof (int), 7);
        public static string Table = "Course";
        public static string Entity = "Course";
        public static string Label = "课程";

        public static IList<IProperty> Properties = new List<IProperty>
                                                        {
                                                            Id,
                                                            Name,
                                                            Teacher,
                                                            Hours,
                                                            Credit,
                                                            Period,
                                                            Location,
                                                            MaxCapacity
                                                        };
    }
}