namespace April.Entity.Base
{
    public enum Role
    {
        Administrator,
        Teacher,
        Student
    }

    public static class RoleEx
    {
        public static string ToEntity(this Role role)
        {
            switch (role)
            {
                case Role.Administrator:
                    return "Administrator";
                case Role.Student:
                    return "Student";
                case Role.Teacher:
                    return "Teacher";
                default:
                    return "Administrator";
            }
        }

        public static string ToLabel(this Role role)
        {
            switch (role)
            {
                case Role.Administrator:
                    return "管理员";
                case Role.Student:
                    return "学生";
                case Role.Teacher:
                    return "教师";
                default:
                    return "管理员";
            }
        }
    }
}