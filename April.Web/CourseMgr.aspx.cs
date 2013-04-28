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
using April.Entity.Exception;
using April.Web.Base;

namespace April.Web
{
    public partial class CourseMgr : MgrPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            gvCourses.DataBind();

            if (IsEdit)
            {
                cmbTeacher.DataBind();
                
                viewForm.Visible = false;
                editForm.Visible = true;
                if (string.IsNullOrEmpty(Id) || Item as ICourse == null)
                {
                    txtName.Text = string.Empty;
                    txtCredit.Text = string.Empty;
                    txtHours.Text = string.Empty;
                    txtPeriod.Text = string.Empty;
                    txtLocation.Text = string.Empty;
                    txtMax.Text = string.Empty;
                    cmbTeacher.SelectedIndex = 0;

                    btnReset.Visible = false;
                }
                else
                {
                    ICourse course = Item as ICourse;
                    txtName.Text = course.Name;
                    txtCredit.Text = Convert.ToString(course.Credit);
                    txtHours.Text = Convert.ToString(course.Hours);
                    txtPeriod.Text = Convert.ToString(course.Period);
                    txtLocation.Text = course.Location;
                    txtMax.Text = Convert.ToString(course.MaxCapacity);
                    cmbTeacher.SelectedValue = course.Teacher.Id;

                    btnReset.Visible = true;
                    btnReset.NavigateUrl = string.Format("~/CourseMgr.aspx?Id={0}&Mode=Edit", Id);
                }
            }
            else
            {
                editForm.Visible = false;
                viewForm.Visible = !string.IsNullOrEmpty(Id) && Item as ICourse != null;
                if (!string.IsNullOrEmpty(Id) && Item as ICourse != null)
                {
                    ICourse course = Item as ICourse;
                    lblvName.Text = string.IsNullOrEmpty(course.Name) ? "无" : course.Name;
                    lblvTeacher.Text = course.Teacher==null || string.IsNullOrEmpty(course.Teacher.Name) ? "无" : course.Teacher.Name;
                    lblvCredit.Text = course.Credit == null ? "无" : Convert.ToString(course.Credit);
                    lblvHours.Text = course.Hours == null ? "无" : Convert.ToString(course.Hours);
                    lblvPeriod.Text = course.Period == null ? "无" : Convert.ToString(course.Period);
                    lblvMax.Text = course.MaxCapacity == null ? "无" : Convert.ToString(course.MaxCapacity);
                    lblvLocation.Text = string.IsNullOrEmpty(course.Location) ? "无" : course.Location;
                }
                btnEdit.NavigateUrl = string.Format("~/CourseMgr.aspx?Id={0}&Mode=Edit", Id);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gvCourses_DataBinding(object sender, EventArgs e)
        {
            gvCourses.DataSource = BLL.CourseMgr.List();
        }
        
        protected void btnSave_Click(object sender, EventArgs e)
        {
            IDictionary<string, object> values = new Dictionary<string, object>();

            string name = txtName.Text.Trim();
            string credit = txtCredit.Text.Trim();
            string hours = txtHours.Text.Trim();
            string period = txtPeriod.Text.Trim();
            string teacher = cmbTeacher.SelectedValue;
            string location = txtLocation.Text.Trim();
            string max = txtMax.Text.Trim();

            values.Add(Course.Name.Name, string.IsNullOrEmpty(name) ? null : name);
            values.Add(Course.Credit.Name, string.IsNullOrEmpty(credit) ? (object)null : Convert.ToInt32(credit));
            values.Add(Course.Hours.Name, string.IsNullOrEmpty(hours) ? (object)null : Convert.ToInt32(hours));
            values.Add(Course.Period.Name, string.IsNullOrEmpty(period) ? (object)null : Convert.ToInt32(period));
            values.Add(Course.Teacher.Name, string.IsNullOrEmpty(teacher) ? (object)null : teacher);
            values.Add(Course.Location.Name, string.IsNullOrEmpty(location) ? null : location);
            values.Add(Course.MaxCapacity.Name, string.IsNullOrEmpty(max) ? (object)null : Convert.ToInt32(max));

            if (string.IsNullOrEmpty(Id))
                values.Add(Course.Id.Name, Guid.NewGuid());
            else
                values.Add("oId", Id);

            try
            {
                if (!string.IsNullOrEmpty(Id))
                {
                    BLL.CourseMgr.Update(values);
                    lblMessage.Text = "修改" + EntityLabel + "成功！";
                }
                else
                {
                    if (BLL.CourseMgr.IsExisting(name))
                        throw new ExistingBaseObjException(Course.Label, name);

                    BLL.CourseMgr.Insert(values);
                    lblMessage.Text = "添加" + EntityLabel + "成功！";
                }

                gvCourses.DataBind();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        protected void gvCourses_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                string id = Convert.ToString(e.CommandArgument);
                try
                {
                    BLL.CourseMgr.Delete(id);
                    lblMessage.Text = "删除" + EntityLabel + "成功！";
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                }
            }
        }

        protected void gvCourses_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            gvCourses.DataBind();
        }

        protected void Refresh_Click(object sender, EventArgs e)
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

        protected void cmbTeacher_DataBinding(object sender, EventArgs e)
        {
            IList<IUser> teachers = UserMgr.List(Role.Teacher);
            cmbTeacher.DataSource = teachers;
            cmbTeacher.DataTextField = "Name";
            cmbTeacher.DataValueField = "Id";
        }

        protected void cmbTeacher_DataBound(object sender, EventArgs e)
        {
            cmbTeacher.Items.Insert(0,new ListItem("--选择教师--",string.Empty));
        }

        protected void lblTeacher_DataBinding(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            if(lbl==null) return;
            GridViewRow row = lbl.NamingContainer as GridViewRow;
            if(row==null)return;
            ICourse course = row.DataItem as ICourse;
            if (course == null) return;
            lbl.Text = course.Teacher == null || string.IsNullOrEmpty(course.Teacher.Name) ? "无" : course.Teacher.Name;

        }
    }
}