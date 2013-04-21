#region

using System;
using System.Collections.Generic;
using April.Core;
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
                try
                {
                    ICourse course = CourseGateway.Get(cmd, id);
                    if (course == null)
                        throw new CourseNotFoundException();
                    cmd.Commint();
                    return course;
                }
                catch (CourseNotFoundException)
                {
                    cmd.RollBack();
                    throw;
                }
                catch
                {
                    cmd.RollBack();
                    throw new CourseNotFoundException();
                }
            }
        }

        public static IList<ICourse> List()
        {
            using (Command cmd=new Command("list_Course"))
            {
                try
                {
                    IList<ICourse> list= CourseGateway.List(cmd);
                    cmd.Commint();
                    return list;
                }
                catch
                {
                    cmd.RollBack();
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
                    throw new CourseInsertedException();
                }
                catch (CourseInsertedException)
                {
                    throw;
                }
                catch
                {
                    cmd.RollBack();
                    throw new CourseInsertedException();
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
                    throw new CourseUpdatedException();
                }
                catch (CourseUpdatedException)
                {
                    throw;
                }
                catch
                {
                    cmd.RollBack();
                    throw new CourseUpdatedException();
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
                        throw new CourseDeleteException();
                    cmd.Commint();
                    return true;
                }
                catch (CourseDeleteException)
                {
                    cmd.RollBack();
                    throw;
                }
                catch
                {
                    cmd.RollBack();
                    throw new CourseDeleteException();
                }
            }
        }
    }
}