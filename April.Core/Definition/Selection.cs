﻿using System;
using System.Collections.Generic;
using System.Text;
using April.Entity.Base;
using April.EntityImpl.Base;

namespace April.Core.Definition
{
    public class Selection
    {
        public static IProperty Id = new Property("Id", "学号", typeof(string), 0);
        //public static IProperty Name = new Property("Name", "姓名", typeof(string), 1);
        public static IProperty Course = new Property("Course", "课程名", typeof(string), 2);
        public static IProperty Student = new Property("Student", "学生名", typeof(string), 3);
        public static IProperty Score = new Property("Score", "分数", typeof(int), 4);
        public static string Table = "Course_Student";
        public static string Entity = "Selection";
        public static string Label = "选课信息";

        public static IList<IProperty> Properties = new List<IProperty> {Id, /*Name,*/ Course, Student,Score};
    }
}
