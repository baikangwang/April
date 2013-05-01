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
    public partial class ScoreQuery : MgrPage
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
            gvCourses.DataSource = SelectionMgr.ListByStudent(LoginUser.Id);
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

        protected void Teacher_DataBinding(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            if (lbl == null) return;
            GridViewRow row = lbl.NamingContainer as GridViewRow;
            if (row == null) return;
            ISelection selection = row.DataItem as ISelection;
            if (selection == null || selection.Course == null || selection.Course.Teacher == null) return;
            lbl.Text = string.IsNullOrEmpty(selection.Course.Teacher.Name) ? "无" : selection.Course.Teacher.Name;
        }

        protected void Credit_DataBinding(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            if (lbl == null) return;
            GridViewRow row = lbl.NamingContainer as GridViewRow;
            if (row == null) return;
            ISelection selection = row.DataItem as ISelection;
            if (selection == null || selection.Course == null) return;
            lbl.Text = selection.Course.Credit==null?"无":Convert.ToString(selection.Course.Credit.Value);
        }

        protected void Location_DataBinding(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            if (lbl == null) return;
            GridViewRow row = lbl.NamingContainer as GridViewRow;
            if (row == null) return;
            ISelection selection = row.DataItem as ISelection;
            if (selection == null || selection.Course == null) return;
            lbl.Text = string.IsNullOrEmpty(selection.Course.Location) ? "无" : selection.Course.Location;
        }

        protected void Score_DataBinding(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            if (lbl == null) return;
            GridViewRow row = lbl.NamingContainer as GridViewRow;
            if (row == null) return;
            ISelection selection = row.DataItem as ISelection;
            if (selection == null) return;
            lbl.Text = selection.Score == null ? "无" : Convert.ToString(selection.Score.Value);
        }

        protected void Id_DataBinding(object sender, EventArgs e)
        {
            HyperLink link = sender as HyperLink;
            if (link == null) return;
            GridViewRow row = link.NamingContainer as GridViewRow;
            if (row == null) return;
            ISelection selection = row.DataItem as ISelection;
            if (selection == null || selection.Course == null) return;
            link.Text = selection.Course.Name;
            link.NavigateUrl = string.Format("~/ScoreQuery.aspx?Id={0}", selection.Course.Id);
        }
    }
}