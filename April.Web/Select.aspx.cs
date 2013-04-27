using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using April.Core.Definition;
using April.Entity;
using April.Entity.Exception;

namespace April.Web
{
    public partial class Select : System.Web.UI.Page
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
                viewForm.Visible = !string.IsNullOrEmpty(Id);
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
                    lblMessage.Text = "修改" + Entity + "成功！";
                }
                else
                {
                    ICourse existing;
                    try
                    {
                        existing = BLL.CourseMgr.IsExisting(name);
                    }
                    catch
                    {
                        existing = null;
                    }

                    if (existing != null)
                        throw new CourseExistingException(name);
                    BLL.CourseMgr.Insert(values);
                    lblMessage.Text = "添加" + Entity + "成功！";
                }

                gvCourses.DataBind();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
    }
}