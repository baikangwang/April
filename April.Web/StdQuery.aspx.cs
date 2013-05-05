using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using April.BLL;
using April.Core.Definition;
using April.Entity;
using April.Entity.Base;
using April.Web.Base;

namespace April.Web
{
    public partial class StdQuery : MgrPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            gvCourses.DataBind();

            viewForm.Visible = !string.IsNullOrEmpty(Id) && Item as ICourse != null;
            if (!string.IsNullOrEmpty(Id) && Item as ICourse != null)
            {
                ICourse course = Item as ICourse;
                lblvName.Text = string.IsNullOrEmpty(course.Name) ? "无" : course.Name;
                lblvTeacher.Text = course.Teacher == null || string.IsNullOrEmpty(course.Teacher.Name) ? "无" : course.Teacher.Name;
                lblvCredit.Text = course.Credit == null ? "无" : Convert.ToString(course.Credit);
                lblvHours.Text = course.Hours == null ? "无" : Convert.ToString(course.Hours);
                lblvPeriod.Text = course.Period == null ? "无" : Convert.ToString(course.Period);
                lblvMax.Text = course.MaxCapacity == null ? "无" : Convert.ToString(course.MaxCapacity);
                lblvLocation.Text = string.IsNullOrEmpty(course.Location) ? "无" : course.Location;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Refresh_Click(object sender, EventArgs e)
        {
            gvCourses.DataBind();
        }

        protected void gvCourses_DataBinding(object sender, EventArgs e)
        {
            gvCourses.DataSource = SelectionMgr.ListCoursesByStudent(LoginUser.Id);
        }

        protected void gvCourses_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                string id = Convert.ToString(e.CommandArgument);

                if (id == this.Id)
                {
                    viewForm.Visible = false;
                }

                try
                {
                    ISelection select = SelectionMgr.Get(id, LoginUser.Id);
                    if (select == null)
                    {
                        lblMessage.Text = "选课已取消！";
                        return;
                    }
                    BLL.SelectionMgr.Delete(select.Id);
                    lblMessage.Text = "选课取消成功！";
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                }
            }
        }

        //protected override string Id
        //{
        //    get { return LoginUser == null ? string.Empty : LoginUser.Id; }
        //}

        protected void gvCourses_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            gvCourses.DataBind();
        }

        private IBaseObject _item = null;

        protected override IBaseObject Item
        {
            get
            {
                if (!string.IsNullOrEmpty(Id) && _item == null)
                {
                    try
                    {
                        _item = BLL.CourseMgr.Get(Id);
                    }
                    catch
                    {
                        _item = null;
                    }
                }
                return _item;
            }
        }

        protected override string EntityLabel
        {
            get { return Course.Label; }
        }
    }
}