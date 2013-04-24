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
            gvTeachers.DataBind();

            if (IsEdit)
            {
                viewForm.Visible = false;
                editForm.Visible = true;
                if (string.IsNullOrEmpty(Id) || Item as ITeacher == null)
                {
                    lblPwd.Visible = true;
                    txtPwd.Visible = true;
                    ReqPwd.ValidationGroup = "save";

                    txtId.Text = string.Empty;
                    txtName.Text = string.Empty;
                    txtTitle.Text = string.Empty;
                    txtContactNo.Text = string.Empty;
                    txtPwd.Text = string.Empty;
                    ckbGender.Checked = true;

                    btnReset.Visible = false;
                }
                else
                {
                    lblPwd.Visible = false;
                    txtPwd.Visible = false;
                    ReqPwd.ValidationGroup = string.Empty;

                    ITeacher teacher = Item as ITeacher;
                    txtId.Text = teacher.Id;
                    txtName.Text = teacher.Name;
                    txtTitle.Text = teacher.Title;
                    txtContactNo.Text = teacher.ContactNo;
                    ckbGender.Checked = teacher.Gender == Gender.Male;

                    btnReset.Visible = true;
                    btnReset.NavigateUrl = string.Format("~/TeacherMgr.aspx?Id={0}&Mode=Edit", Id);
                }
            }
            else
            {
                editForm.Visible = false;
                viewForm.Visible = !string.IsNullOrEmpty(Id);
                if (!string.IsNullOrEmpty(Id) && Item as ITeacher != null)
                {
                    lblPwd.Visible = false;
                    txtPwd.Visible = false;

                    ITeacher teacher = Item as ITeacher;
                    lblvId.Text = string.IsNullOrEmpty(teacher.Id) ? "无" : teacher.Id;
                    lblvName.Text = string.IsNullOrEmpty(teacher.Name) ? "无" : teacher.Name;
                    lblvTitle.Text = string.IsNullOrEmpty(teacher.Title) ? "无" : teacher.Title;
                    lblvContactNo.Text = string.IsNullOrEmpty(teacher.ContactNo) ? "无" : teacher.ContactNo;
                    lblvGender.Text = string.IsNullOrEmpty(teacher.Gender.ToLabel()) ? "无" : teacher.Gender.ToLabel();
                }
                btnEdit.NavigateUrl = string.Format("~/TeacherMgr.aspx?Id={0}&Mode=Edit", Id);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gvTeachers_DataBinding(object sender, EventArgs e)
        {
            gvTeachers.DataSource = BLL.CourseMgr.List();
        }
        
        protected void btnSave_Click(object sender, EventArgs e)
        {
            IDictionary<string, object> values = new Dictionary<string, object>();

            values.Add(Course.Id.Name, txtId.Text);
            values.Add(Course.Name.Name, txtName.Text);
            values.Add(Course.Title.Name, txtTitle.Text);
            values.Add(Course.Gender.Name, ckbGender.Checked ? Gender.Male : Gender.Female);
            values.Add(Course.ContactNo.Name, txtContactNo.Text);

            if (string.IsNullOrEmpty(Id))
                values.Add(Course.Password.Name, txtPwd.Text);
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
                    string id = txtId.Text;

                    ICourse existing;
                    try
                    {
                        existing = BLL.CourseMgr.Get(id);
                    }
                    catch
                    {
                        existing = null;
                    }
                    if (existing != null)
                        throw new CourseNotFoundException();
                    BLL.CourseMgr.Insert(values);
                    lblMessage.Text = "添加" + Entity + "成功！";
                }

                gvTeachers.DataBind();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        protected void gvTeachers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                string id = Convert.ToString(e.CommandArgument);
                try
                {
                    BLL.CourseMgr.Delete(id);
                    lblMessage.Text = "删除" + Entity + "成功！";
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                }
            }
        }

        protected void gvTeachers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            gvTeachers.DataBind();
        }

        protected void Refresh_Click(object sender, EventArgs e)
        {
            gvTeachers.DataBind();
        }

        protected override IBaseObject Item
        {
            get
            {
                if (!string.IsNullOrEmpty(Id))
                    return April.BLL.CourseMgr.Get(Id);
                return null;
            }
        }

        protected override string Entity
        {
            get { return "课程"; }
        }
    }
}