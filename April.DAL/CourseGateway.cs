#region

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using April.Core;
using April.Core.Definition;
using April.DAL.Factory;
using April.Entity;

#endregion

namespace April.DAL
{
    public class CourseGateway
    {

        public static ICourse Get(Command cmd, string id)
        {
            string table = Course.Table;
            string columns = string.Join(",", Course.Properties.Select(p => p.Name == "Teacher" ? p.Name + "_Id" : p.Name).ToArray());
            string sql = string.Format(@"select {0} from {1} where lower(Id)=lower(@Id)", columns, table);
            cmd.CommandText = sql;
            cmd.AddParameter("@Id", id);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                ICourse course = ReaderFactory.Reader(reader, Course.Entity) as ICourse;
                reader.Close();
                return course;
            }
            reader.Close();
            return null;
        }

        public static ICourse GetByName(Command cmd,string name)
        {
            string table = Course.Table;
            string columns = string.Join(",", Course.Properties.Select(p => p.Name == "Teacher" ? p.Name + "_Id" : p.Name).ToArray());
            string sql = string.Format(@"select {0} from {1} where lower(Name)=lower(@Name)", columns, table);
            cmd.CommandText = sql;
            cmd.AddParameter("@Name", name);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                ICourse course = ReaderFactory.Reader(reader, Course.Entity) as ICourse;
                reader.Close();
                return course;
            }
            reader.Close();
            return null;
        }

        public static IList<ICourse> List(Command cmd)
        {
            string table = Course.Table;
            string columns = string.Join(",", Course.Properties.Select(p => p.Name == "Teacher" ? p.Name + "_Id" : p.Name).ToArray());
            string sql = string.Format(@"select {0} from {1}", columns, table);
            cmd.CommandText = sql;
            SqlDataReader reader = cmd.ExecuteReader();

            IList<ICourse> courses = new List<ICourse>();

            while (reader.Read())
            {
                ICourse course = ReaderFactory.Reader(reader, Course.Entity) as ICourse;
                if (course != null)
                    courses.Add(course);
            }
            reader.Close();
            return courses;
        }

        public static IList<ICourse> ListByTeacher(Command cmd, string teacherId)
        {
            string table = Course.Table;
            string columns = string.Join(",", Course.Properties.Select(p => p.Name == "Teacher" ? p.Name + "_Id" : p.Name).ToArray());
            string sql = string.Format(@"select {0} from {1} where lower(Teacher_Id)=@TeacherId", columns, table);
            cmd.CommandText = sql;
            cmd.AddParameter("@TeacherId", teacherId);
            SqlDataReader reader = cmd.ExecuteReader();

            IList<ICourse> courses = new List<ICourse>();

            while (reader.Read())
            {
                ICourse course = ReaderFactory.Reader(reader, Course.Entity) as ICourse;
                if (course != null)
                    courses.Add(course);
            }
            reader.Close();
            return courses;
        }

        public static bool Insert(Command cmd, IDictionary<string, object> values)
        {
            string table = Course.Table;
            string columns = string.Join(",", values.Keys.Select(p => p == "Teacher" ? p + "_Id" : p).ToArray());
            string paras = string.Join(",", values.Keys.Select(p => "@" + (p == "Teacher" ? p + "_Id" : p)).ToArray());
            string sql = string.Format(@"insert {1} ({0}) values ({2})", columns, table, paras);
            cmd.CommandText = sql;
            foreach (string field in values.Keys)
            {
                if (field == "Teacher")
                    cmd.AddParameter("@" + field + "_Id", values[field]);
                else
                    cmd.AddParameter("@" + field, values[field]);
            }
            int result = cmd.ExecuteNonQuery();
            return result > 0;
        }

        public static bool Update(Command cmd, IDictionary<string, object> values)
        {
            string table = Course.Table;
            string cals = string.Join(",",
                                      (from p in values.Keys where p!="oId"
                                       let n = (p == "Teacher" ? p + "_Id" : p)
                                       select n + "=" + "@" + n).ToArray());
            string sql = string.Format(@"update {1} set {0} where Id=@oId", cals, table);
            cmd.CommandText = sql;
            foreach (string field in values.Keys)
            {
                if (field == "Teacher")
                    cmd.AddParameter("@" + field + "_Id", values[field]);
                else
                    cmd.AddParameter("@" + field, values[field]);
            }
            int result = cmd.ExecuteNonQuery();
            return result > 0;
        }

        public static bool Delete(Command cmd, string id)
        {
            string table = Course.Table;
            string sql = string.Format(@"delete from {0} where Id=@Id", table);
            cmd.CommandText = sql;
            cmd.AddParameter("@Id", id);
            int result = cmd.ExecuteNonQuery();
            return result > 0;
        }
    }
}