using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using April.Web.Base;
using April.Entity;
using April.Entity.Base;
using April.BLL;
using April.Core.Definition;
using April.Entity.Exception;

namespace April.Web
{
    public partial class TeacherMgr : UserMgrPage
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
                    ckbGender.Checked = true; // Gender.Male

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
            gvTeachers.DataSource = UserMgr.List(Role);
        }

        protected override Role Role
        {
            get { return Role.Teacher; }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            IDictionary<string, object> values = new Dictionary<string, object>();

            values.Add(Teacher.Id.Name, txtId.Text);
            values.Add(Teacher.Name.Name, txtName.Text);
            values.Add(Teacher.Title.Name, txtTitle.Text);
            values.Add(Teacher.Gender.Name, ckbGender.Checked ? Gender.Male : Gender.Female);
            values.Add(Teacher.ContactNo.Name, txtContactNo.Text);

            if (string.IsNullOrEmpty(Id))
                values.Add(Teacher.Password.Name, txtPwd.Text);
            else
                values.Add("oId", Id);

            try
            {
                if (!string.IsNullOrEmpty(Id))
                {
                    UserMgr.Update(Role, values);
                    lblMessage.Text = "修改" + Role.ToLabel() + "成功！";
                }
                else
                {
                    string id = txtId.Text;

                    IUser existing;
                    try
                    {
                        existing = UserMgr.Get(id, Role);
                    }
                    catch
                    {
                        existing = null;
                    }
                    if (existing != null)
                        throw new UserExistingException(Role, id);
                    UserMgr.Insert(Role, values);
                    lblMessage.Text = "添加" + Role.ToLabel() + "成功！";
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
                    UserMgr.Delete(Role, id);
                    lblMessage.Text = "删除" + Role.ToLabel() + "成功！";
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
    }
}