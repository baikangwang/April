#region

using System;
using System.Collections.Generic;
using April.Core;
using April.Core.Definition;
using April.DAL;
using April.Entity;
using April.Entity.Exception;

#endregion

namespace April.BLL
{
    public class CourseMgr
    {
        public static ICourse Get(string id)
        {
            using (Command cmd = new Command("Get"))
            {
                ICourse course = CourseGateway.Get(cmd, id);
                return course;
            }
        }

        public static bool IsExisting(string name)
        {
            using (Command cmd = new Command("Get"))
            {
                try
                {
                    ICourse course = CourseGateway.GetByName(cmd, name);
                    return course != null;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static IList<ICourse> List()
        {
            using (Command cmd=new Command("list_Course"))
            {
                try
                {
                    return CourseGateway.List(cmd);
                }
                catch
                {
                    return new List<ICourse>();
                }
            }
        }

        public static IList<ICourse> ListByTeacher(string teacherId)
        {
            using(Command cmd=new Command("listByTeacher_Course"))
            {
                try
                {
                    return CourseGateway.ListByTeacher(cmd, teacherId);

                }
                catch
                {
                   return new List<ICourse>();
                }
            }
        }

        public static bool Insert(IDictionary<string, object> values)
        {
            using (Command cmd = new Command("insert_Course"))
            {
                try
                {
                    if(CourseGateway.Insert(cmd, values))
                    {
                        cmd.Commint();
                        return true;
                    }
                    
                    cmd.RollBack();
                    throw new InsertBaseObjException(Course.Label, Convert.ToString(values["Name"]));
                }
                catch (InsertBaseObjException)
                {
                    throw;
                }
                catch
                {
                    cmd.RollBack();
                    throw new InsertBaseObjException(Course.Label, Convert.ToString(values["Name"]));
                }
            }
        }

        public static bool Update(IDictionary<string, object> values)
        {
            using (Command cmd = new Command("update_Course"))
            {
                try
                {
                    if (CourseGateway.Update(cmd, values))
                    {
                        cmd.Commint();
                        return true;
                    }

                    cmd.RollBack();
                    throw new UpdateBaseObjException(Course.Label, Convert.ToString(values["Name"]));
                }
                catch (UpdateBaseObjException)
                {
                    throw;
                }
                catch
                {
                    cmd.RollBack();
                    throw new UpdateBaseObjException(Course.Label, Convert.ToString(values["Name"]));
                }
            }
        }

        public static bool Delete(string id)
        {
            using (Command cmd = new Command("delete_Course"))
            {
                try
                {
                    bool result = CourseGateway.Delete(cmd, id);
                    if (!result)
                        throw new DeleteBaseObjException(Course.Label, id);
                    cmd.Commint();
                    return true;
                }
                catch (DeleteBaseObjException)
                {
                    cmd.RollBack();
                    throw;
                }
                catch
                {
                    cmd.RollBack();
                    throw new DeleteBaseObjException(Course.Label, id);
                }
            }
        }
    }
}