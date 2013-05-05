using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using April.Core;
using April.Core.Definition;
using April.DAL.Factory;
using April.Entity;

namespace April.DAL
{
    public class SelectionGateway
    {
        public static ISelection Get(Command cmd, string id)
        {
            string table = Selection.Table;
            string columns = string.Join(",", Selection.Properties.Select(p => p.Name != "Id" && p.Name != "Score" ? p.Name + "_Id" : p.Name).ToArray());
            string sql = string.Format(@"select {0} from {1} where lower(Id)=lower(@Id)", columns, table);
            cmd.CommandText = sql;
            cmd.AddParameter("@Id", id);
            SqlCeDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                ISelection course = ReaderFactory.Reader(reader, Selection.Entity) as ISelection;
                reader.Close();
                return course;
            }
            reader.Close();
            return null;
        }

        public static ISelection Get(Command cmd,string courseId,string studentId)
        {
            string table = Selection.Table;
            string columns = string.Join(",", Selection.Properties.Select(p => p.Name != "Id" && p.Name!="Score" ? p.Name + "_Id" : p.Name).ToArray());
            string sql = string.Format(@"select {0} from {1} where lower(Course_Id)=lower(@Course_Id) and lower(Student_Id)=lower(@Student_Id)", columns, table);
            cmd.CommandText = sql;
            cmd.AddParameter("@Course_Id", courseId);
            cmd.AddParameter("@Student_Id", studentId);
            SqlCeDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                ISelection selction = ReaderFactory.Reader(reader, Selection.Entity) as ISelection;
                reader.Close();
                return selction;
            }
            reader.Close();
            return null;
        }

        public static int CountByCourse(Command cmd,string courseId)
        {
            string table = Selection.Table;
            string sql = string.Format(@"select count(*) from {0} where lower(Course_Id)=lower(@Course_Id)", table);
            cmd.CommandText = sql;
            cmd.AddParameter("@Course_Id", courseId);
            object count = cmd.ExecuteScalar();

            return (count == null || count is DBNull) ? 0 : Convert.ToInt32(count);
        }

        public static IList<IStudent> ListStudentsByCourse(Command cmd,string courseId)
        {
            string table = Selection.Table;
            string columns = string.Join(",", Selection.Properties.Select(p => p.Name != "Id" && p.Name != "Score" ? p.Name + "_Id" : p.Name).ToArray());
            string sql = string.Format(@"select {0} from {1} where lower(Course_Id)=lower(@Course_Id)", columns, table);
            cmd.CommandText = sql;
            cmd.AddParameter("@Course_Id", courseId);
            SqlCeDataReader reader = cmd.ExecuteReader();

            IList<IStudent> students=new List<IStudent>();
            while (reader.Read())
            {
                ISelection selction = ReaderFactory.Reader(reader, Selection.Entity) as ISelection;
                if(selction!=null && selction.Student!=null)
                    students.Add(selction.Student);
            }
            
            reader.Close();
            return students;
        }

        public static IList<ISelection> ListByCourse(Command cmd,string courseId)
        {
            string table = Selection.Table;
            string columns = string.Join(",", Selection.Properties.Select(p => p.Name != "Id" && p.Name != "Score" ? p.Name + "_Id" : p.Name).ToArray());
            string sql = string.Format(@"select {0} from {1} where lower(Course_Id)=lower(@Course_Id)", columns, table);
            cmd.CommandText = sql;
            cmd.AddParameter("@Course_Id", courseId);
            SqlCeDataReader reader = cmd.ExecuteReader();

            IList<ISelection> selections = new List<ISelection>();
            while (reader.Read())
            {
                ISelection selction = ReaderFactory.Reader(reader, Selection.Entity) as ISelection;
                if (selction != null)
                    selections.Add(selction);
            }

            reader.Close();
            return selections;
        }

        public static IList<ISelection> ListByStudent(Command cmd,string studentId)
        {
            string table = Selection.Table;
            string columns = string.Join(",", Selection.Properties.Select(p => p.Name != "Id" && p.Name != "Score" ? p.Name + "_Id" : p.Name).ToArray());
            string sql = string.Format(@"select {0} from {1} where lower(Student_Id)=lower(@Student_Id)", columns, table);
            cmd.CommandText = sql;
            cmd.AddParameter("@Student_Id", studentId);
            SqlCeDataReader reader = cmd.ExecuteReader();

            IList<ISelection> selections = new List<ISelection>();
            while (reader.Read())
            {
                ISelection selction = ReaderFactory.Reader(reader, Selection.Entity) as ISelection;
                if (selction != null)
                    selections.Add(selction);
            }

            reader.Close();
            return selections;
        }

        public static IList<ICourse> ListCoursesByStudent(Command cmd,string studentId)
        {
            string table = Selection.Table;
            string columns = string.Join(",", Selection.Properties.Select(p => p.Name != "Id" && p.Name != "Score" ? p.Name + "_Id" : p.Name).ToArray());
            string sql = string.Format(@"select {0} from {1} where lower(Student_Id)=lower(@Student_Id)", columns, table);
            cmd.CommandText = sql;
            cmd.AddParameter("@Student_Id", studentId);
            SqlCeDataReader reader = cmd.ExecuteReader();

            IList<ICourse> students = new List<ICourse>();
            while (reader.Read())
            {
                ISelection selction = ReaderFactory.Reader(reader, Selection.Entity) as ISelection;
                if (selction != null && selction.Course != null)
                    students.Add(selction.Course);
            }

            reader.Close();
            return students;
        }

        public static bool Insert(Command cmd,IDictionary<string,object> values)
        {
            string table = Selection.Table;
            string columns = string.Join(",", values.Keys.Select(p => p != "Id" && p != "Score" ? p + "_Id" : p).ToArray());
            string paras = string.Join(",", values.Keys.Select(p => "@" + (p != "Id" && p != "Score" ? p + "_Id" : p)).ToArray());
            string sql = string.Format(@"insert {1} ({0}) values ({2})", columns, table, paras);
            cmd.CommandText = sql;
            foreach (string field in values.Keys)
            {
                if (field != "Id" && field != "Score")
                    cmd.AddParameter("@" + field+"_Id", values[field]);
                else
                    cmd.AddParameter("@" + field, values[field]);
            }
            int result = cmd.ExecuteNonQuery();
            return result > 0;
        }

        public static bool Update(Command cmd,IDictionary<string,object> values )
        {
            string table = Selection.Table;
            string cals = string.Join(",",
                                      (from p in values.Keys
                                       where p != "oId"
                                       let n = (p != "Id" && p != "Score" ? p + "_Id" : p)
                                       select n + "=" + "@" + n).ToArray());
            string sql = string.Format(@"update {1} set {0} where Id=@oId", cals, table);
            cmd.CommandText = sql;
            foreach (string field in values.Keys)
            {
                if (field != "Id" && field!="Score" && field!="oId")
                    cmd.AddParameter("@" + field + "_Id", values[field]);
                else
                    cmd.AddParameter("@" + field, values[field]);
            }
            int result = cmd.ExecuteNonQuery();
            return result > 0;
        }

        public static bool Delete(Command cmd,string id)
        {
            string table = Selection.Table;
            string sql = string.Format(@"delete from {0} where Id=@Id", table);
            cmd.CommandText = sql;
            cmd.AddParameter("@Id", id);
            int result = cmd.ExecuteNonQuery();
            return result > 0;
        }
    }
}
