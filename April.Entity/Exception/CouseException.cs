#region

using System;

#endregion

namespace April.Entity.Exception
{
    public class CourseNotFoundException : ApplicationException
    {
        public override string Message
        {
            get
            {
                string msg = "该课程没有找到。";
                return msg;
            }
        }
    }

    public class CourseInsertedException : ApplicationException
    {
        public override string Message
        {
            get
            {
                string msg = "添加课程失败。";
                return msg;
            }
        }
    }

    public class CourseUpdatedException : ApplicationException
    {
        public override string Message
        {
            get { return "修改课程失败。"; }
        }
    }

    public class CourseDeleteException : ApplicationException
    {
        public override string Message
        {
            get { return "删除课程失败。"; }
        }
    }
}