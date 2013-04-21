#region

using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using April.Core;
using April.Core.Definition;
using April.DAL.Factory;
using April.Entity;
using April.Entity.Base;

#endregion

namespace April.DAL
{
    public class UserGateway
    {
        public static IUser Get(Command cmd, string id, Role role)
        {
            string table = null;
            string columns = null;
            switch (role)
            {
                case Role.Administrator:
                    table = Administrator.Table;
                    columns = string.Join(",", Administrator.Properties.Select(p => p.Name).ToArray());
                    break;
                case Role.Teacher:
                    table = Teacher.Table;
                    columns = string.Join(",", Teacher.Properties.Select(p => p.Name).ToArray());
                    break;
                case Role.Student:
                    table = Student.Table;
                    columns = string.Join(",", Student.Properties.Select(p => p.Name).ToArray());
                    break;
            }
            string sql = string.Format(@"select {0} from {1} where lower(Id)=lower(@Id)", columns, table);
            cmd.CommandText = sql;
            cmd.AddParameter("@Id", id);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                IUser user = ReaderFactory.Reader(reader, role.ToEntity()) as IUser;
                reader.Close();
                return user;
            }
            reader.Close();
            return null;
        }

        public static IList<IUser> List(Command cmd, Role role)
        {
            string table = null;
            string columns = null;
            switch (role)
            {
                case Role.Administrator:
                    table = Administrator.Table;
                    columns = string.Join(",", Administrator.Properties.Select(p => p.Name).ToArray());
                    break;
                case Role.Teacher:
                    table = Teacher.Table;
                    columns = string.Join(",", Teacher.Properties.Select(p => p.Name).ToArray());
                    break;
                case Role.Student:
                    table = Student.Table;
                    columns = string.Join(",", Student.Properties.Select(p => p.Name).ToArray());
                    break;
            }
            string sql = string.Format(@"select {0} from {1}", columns, table);
            cmd.CommandText = sql;
            SqlDataReader reader = cmd.ExecuteReader();

            IList<IUser> users = new List<IUser>();
            while (reader.Read())
            {
                IUser user = ReaderFactory.Reader(reader, role.ToEntity()) as IUser;
                if (user != null)
                    users.Add(user);
            }
            reader.Close();
            return users;
        }

        public static bool Insert(Command cmd, Role role, IDictionary<string, object> values)
        {
            string table = null;
            string columns = string.Join(",", values.Keys.Select(p => p).ToArray());
            string paras = string.Join(",", values.Keys.Select(p => "@" + p).ToArray());
            switch (role)
            {
                case Role.Administrator:
                    table = Administrator.Table;
                    break;
                case Role.Teacher:
                    table = Teacher.Table;
                    break;
                case Role.Student:
                    table = Student.Table;
                    break;
            }
            string sql = string.Format(@"insert {1} ({0}) values ({2})", columns, table, paras);
            cmd.CommandText = sql;
            foreach (string field in values.Keys)
            {
                cmd.AddParameter("@" + field, values[field]);
            }
            int result = cmd.ExecuteNonQuery();
            return result > 0;
        }

        public static bool Update(Command cmd, Role role, IDictionary<string, object> values)
        {
            string table = null;
            string cals = string.Join(",", values.Keys.Where( p=>p!="oId").Select(p => p + "=" + "@" + p).ToArray());
            switch (role)
            {
                case Role.Administrator:
                    table = Administrator.Table;
                    break;
                case Role.Teacher:
                    table = Teacher.Table;
                    break;
                case Role.Student:
                    table = Student.Table;
                    break;
            }
            string sql = string.Format(@"update {1} set {0} where Id=@oId", cals, table);
            cmd.CommandText = sql;
            foreach (string field in values.Keys)
            {
                cmd.AddParameter("@" + field, values[field]);
            }
            int result = cmd.ExecuteNonQuery();
            return result > 0;
        }

        public static bool Delete(Command cmd, Role role, string id)
        {
            string table = null;
            switch (role)
            {
                case Role.Administrator:
                    table = Administrator.Table;
                    break;
                case Role.Teacher:
                    table = Teacher.Table;
                    break;
                case Role.Student:
                    table = Student.Table;
                    break;
            }
            string sql = string.Format(@"delete from {0} where Id=@Id", table);
            cmd.CommandText = sql;
            cmd.AddParameter("@Id", id);
            int result = cmd.ExecuteNonQuery();
            return result > 0;
        }

        public static IUser Authenticate(Command cmd, string id, string pwd, Role role)
        {
            string table = null;
            string columns = null;
            switch (role)
            {
                case Role.Administrator:
                    table = Administrator.Table;
                    columns = string.Join(",", Administrator.Properties.Select(p => p.Name).ToArray());
                    break;
                case Role.Teacher:
                    table = Teacher.Table;
                    columns = string.Join(",", Teacher.Properties.Select(p => p.Name).ToArray());
                    break;
                case Role.Student:
                    table = Student.Table;
                    columns = string.Join(",", Student.Properties.Select(p => p.Name).ToArray());
                    break;
            }
            string sql = string.Format(@"select {0} from {1} where lower(Id)=lower(@Id) and Password=@pwd", columns,
                                       table);
            cmd.CommandText = sql;
            cmd.AddParameter("@Id", id);
            cmd.AddParameter("@pwd", pwd);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                IUser user = ReaderFactory.Reader(reader, role.ToEntity()) as IUser;
                reader.Close();
                return user;
            }
            reader.Close();
            return null;
        }
    }
}