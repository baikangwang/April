using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using April.Core;
using April.Core.Definition;
using April.DAL;
using April.Entity;
using April.Entity.Exception;

namespace April.BLL
{
    public class SelectionMgr
    {
        public static bool Insert(IDictionary<string, object> values)
        {
            if(!values.ContainsKey("Score"))
                values.Add("Score",null);

            using (Command cmd=new Command("insert_"+Selection.Entity))
            {
                try
                {
                    if( SelectionGateway.Insert(cmd, values))
                    {
                        cmd.Commint();
                        return true;
                    }
                    cmd.RollBack();
                    throw new InsertBaseObjException(Selection.Label,Convert.ToString(values["Id"]));
                }
                catch (InsertBaseObjException)
                {
                    throw;
                }
                catch
                {
                    cmd.RollBack();
                    throw new InsertBaseObjException(Selection.Label, Convert.ToString(values["Id"]));
                }
            }
        }

        public static bool Delete(string id)
        {
            using (Command cmd = new Command("delete_"+Selection.Entity))
            {
                try
                {
                    if (SelectionGateway.Delete(cmd, id))
                    {
                        cmd.Commint();
                        return true;
                    }
                    cmd.RollBack();
                    throw new DeleteBaseObjException(Selection.Label, id);
                }
                catch (DeleteBaseObjException)
                {
                    throw;
                }
                catch
                {
                    cmd.RollBack();
                    throw new DeleteBaseObjException(Selection.Label, id);
                }
            }
        }

        public static bool IsExisting(string courseId,string studentId)
        {
            using (Command cmd=new Command("isExisting_"+Selection.Entity))
            {
                try
                {
                    ISelection item = SelectionGateway.Get(cmd, courseId,studentId);
                    return item != null;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static ISelection Get(string courseId,string studentId)
        {
            using (Command cmd = new Command("Get_" + Selection.Entity))
            {
                try
                {
                    return SelectionGateway.Get(cmd, courseId,studentId);
                }
                catch
                {
                    return null;
                }
            }
        }

        public static bool IsMax(ICourse course)
        {
            if(course.MaxCapacity==null)
                return false;
            
            int count;
            
            using (Command cmd=new Command("count_"+Selection.Entity))
            {
                try
                {
                    count = SelectionGateway.CountByCourse(cmd, course.Id);
                }
                catch
                {
                    count = 0;
                }
            }

            return count >= course.MaxCapacity.Value;
        }

        public static IList<IStudent> ListStudentsByCourse(string courseId)
        {
            using (Command cmd=new Command("listByCourse_"+Selection.Entity))
            {
                try
                {
                    return SelectionGateway.ListStudentsByCourse(cmd, courseId);
                }
                catch
                {
                    return new List<IStudent>();
                }
            }
        }

        public static IList<ICourse> ListCoursesByStudent(string studentId)
        {
            using (Command cmd = new Command("ListByStudent_" + Selection.Entity))
            {
                try
                {
                    return SelectionGateway.ListCoursesByStudent(cmd, studentId);
                }
                catch
                {
                    return new List<ICourse>();
                }
            }
        }

        public static IList<ISelection> ListByCourse(string courseId)
        {
            using (Command cmd=new Command("list_"+Selection.Entity))
            {
                try
                {
                    return SelectionGateway.ListByCourse(cmd, courseId);
                }
                catch
                {
                  return new List<ISelection>();
                }
            }
        }

        public static IList<ISelection> ListByStudent(string studentId)
        {
            using (Command cmd = new Command("list_" + Selection.Entity))
            {
                try
                {
                    return SelectionGateway.ListByStudent(cmd, studentId);
                }
                catch
                {
                    return new List<ISelection>();
                }
            }
        }

        public static bool Update(string courseId, string studentId, int score)
        {
            ISelection target = Get(courseId, studentId);
            using (Command cmd=new Command("update_"+Selection.Entity))
            {
                try
                {
                    IDictionary<string,object> values=new Dictionary<string, object>();
                    values.Add("Score",score);
                    values.Add("oId",target.Id);
                    return SelectionGateway.Update(cmd, values);
                }
                catch
                {
                    cmd.RollBack();
                    return false;
                }
            }
        }

        public static bool Update(IDictionary<string,object> values )
        {
            using (Command cmd = new Command("update_" + Selection.Entity))
            {
                try
                {
                    return SelectionGateway.Update(cmd, values);
                }
                catch
                {
                    cmd.RollBack();
                    return false;
                }
            }
        }
    }
}
