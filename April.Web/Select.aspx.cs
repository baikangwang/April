using System;
using System.Collections.Generic;
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
    public partial class Select : BasePage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            gvCourses.DataBind();

            viewForm.Visible = !string.IsNullOrEmpty(Id);
            if (!string.IsNullOrEmpty(Id) && Item as ICourse != null)
            {
                ICourse course = Item as ICourse;
                lblvName.Text = string.IsNullOrEmpty(course.Name) ? "无" : course.Name;
                lblvTeacher.Text = course.Teacher == null || string.IsNullOrEmpty(course.Teacher.Name)
                                       ? "无"
                                       : course.Teacher.Name;
                lblvCredit.Text = course.Credit == null ? "无" : Convert.ToString(course.Credit);
                lblvHours.Text = course.Hours == null ? "无" : Convert.ToString(course.Hours);
                lblvPeriod.Text = course.Period == null ? "无" : Convert.ToString(course.Period);
                lblvMax.Text = course.MaxCapacity == null ? "无" : Convert.ToString(course.MaxCapacity);
                lblvLocation.Text = string.IsNullOrEmpty(course.Location) ? "无" : course.Location;
                lblvDescription.Text = string.IsNullOrEmpty(course.Description) ? "无" : course.Description;
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
            values.Add(Selection.Course.Name,Id);
            values.Add(Selection.Student.Name,LoginUser.Id);
            string id = Guid.NewGuid().ToString();
            values.Add(Selection.Id.Name, id);

            try
            {
                ICourse course = Item as ICourse;

                if (BLL.SelectionMgr.IsExisting(Id, LoginUser.Id))
                    throw new ExistingBaseObjException(Selection.Label, course.Name);

                if(SelectionMgr.IsMax(Item as ICourse))
                {
                    lblMessage.Text = course.Name + "人数已满！";
                }
                else
                {
                    BLL.SelectionMgr.Insert(values);
                    lblMessage.Text = "选择" + course.Name + "成功！";
                }

                //gvCourses.DataBind();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        protected void Refresh_Click(object sender, EventArgs e)
        {
            gvCourses.DataBind();
        }

        private IBaseObject _item;
        protected IBaseObject Item
        {
            get
            {
                if (!string.IsNullOrEmpty(Id) && _item == null)
                    _item = April.BLL.CourseMgr.Get(Id);
                return _item;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            viewForm.Visible = false;
        }
    }
}