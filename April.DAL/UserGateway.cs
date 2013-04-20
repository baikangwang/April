#region

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

            IUser user = ReaderFactory.Reader(reader, role.ToEntity()) as IUser;

            return user;
        }

        public static IUser Authenticate(Command cmd, string id, string pwd,Role role)
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
            string sql = string.Format(@"select {0} from {1} where lower(Id)=lower(@Id) and Password=@pwd", columns, table);
            cmd.CommandText = sql;
            cmd.AddParameter("@Id", id);
            cmd.AddParameter("@pwd", pwd);
            SqlDataReader reader = cmd.ExecuteReader();

            IUser user = ReaderFactory.Reader(reader, role.ToEntity()) as IUser;

            return user;
        }
    }
}