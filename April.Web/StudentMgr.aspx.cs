using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using April.BLL;
using April.Entity;
using April.Entity.Base;
using April.Entity.Exception;
using April.Web.Base;
using Student = April.Core.Definition.Student;

namespace April.Web
{
    public partial class StudentMgr : UserMgrPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            gvStudents.DataBind();

            if (IsEdit)
            {
                viewForm.Visible = false;
                editForm.Visible = true;
                if (string.IsNullOrEmpty(Id) || Item as IStudent == null)
                {
                    txtId.Text = string.Empty;
                    txtName.Text = string.Empty;
                    txtGrade.Text = string.Empty;
                    txtContactNo.Text = string.Empty;
                    txtAddress.Text = string.Empty;
                    txtPwd.Text = string.Empty;
                    ddlGender.SelectedValue = Convert.ToString((int) Gender.Male);
                    calBirthday.SelectedDate = DateTime.MinValue;

                    btnReset.Visible = false;
                }
                else
                {
                    lblPwd.Visible = false;
                    txtPwd.Visible = false;

                    IStudent student = Item as IStudent;
                    txtId.Text = student.Id;
                    txtName.Text = student.Name;
                    txtGrade.Text = student.Grade;
                    txtAddress.Text = student.Address;
                    txtContactNo.Text = student.ContactNo;
                    calBirthday.SelectedDate = student.Birthday == null ? DateTime.MinValue : student.Birthday.Value;
                    ddlGender.SelectedValue = Convert.ToString(((int) student.Gender));

                    btnReset.Visible = true;
                    btnReset.NavigateUrl = string.Format("~/StudentMgr.aspx?Id={0}&Mode=Edit", Id);
                }
            }
            else
            {
                editForm.Visible = false;
                viewForm.Visible = !string.IsNullOrEmpty(Id);
                if (!string.IsNullOrEmpty(Id) && Item as IStudent != null)
                {
                    lblPwd.Visible = false;
                    txtPwd.Visible = false;

                    IStudent student = Item as IStudent;
                    lblvId.Text = string.IsNullOrEmpty(student.Id) ? "无" : student.Id;
                    lblvName.Text = string.IsNullOrEmpty(student.Name) ? "无" : student.Name;
                    lblvGrade.Text = string.IsNullOrEmpty(student.Grade) ? "无" : student.Grade;
                    lblvAddress.Text = string.IsNullOrEmpty(student.Address) ? "无" : student.Address;
                    lblvContactNo.Text = string.IsNullOrEmpty(student.ContactNo) ? "无" : student.ContactNo;
                    lblvGender.Text = string.IsNullOrEmpty(student.Gender.ToLabel()) ? "无" : student.Gender.ToLabel();
                    lblvBirthday.Text = student.Birthday == null ? "无" : student.Birthday.Value.ToShortDateString();
                }
                btnEdit.NavigateUrl = string.Format("~/StudentMgr.aspx?Id={0}&Mode=Edit", Id);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gvStudents_DataBinding(object sender, EventArgs e)
        {
            gvStudents.DataSource = UserMgr.List(Role);
        }

        protected override Role Role
        {
            get { return Role.Student;}
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            IDictionary<string, object> values = new Dictionary<string, object>();

            values.Add(Student.Id.Name, txtId.Text);
            values.Add(Student.Name.Name, txtName.Text);
            values.Add(Student.Grade.Name, txtGrade.Text);
            values.Add(Student.Gender.Name, (Gender) int.Parse(ddlGender.SelectedValue));
            values.Add(Student.ContactNo.Name, txtContactNo.Text);
            values.Add(Student.Birthday.Name, calBirthday.SelectedDate==DateTime.MinValue?(object) null:calBirthday.SelectedDate);
            values.Add(Student.Address.Name, txtAddress.Text);
            
            if (string.IsNullOrEmpty(Id))
                values.Add(Student.Password.Name, txtPwd.Text);
            else
                values.Add("oId",Id);

            try
            {
                if (!string.IsNullOrEmpty(Id))
                {
                    UserMgr.Update(Role, values);
                    lblMessage.Text = "修改"+Role.ToLabel()+"成功！";
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
                    if(existing!=null)
                        throw new UserExistingException(Role,id);
                    UserMgr.Insert(Role, values);
                    lblMessage.Text = "添加" + Role.ToLabel() + "成功！";
                }

                gvStudents.DataBind();
            }
            catch(Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        protected void gvStudents_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName=="Delete")
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

        protected void gvStudents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            gvStudents.DataBind();
        }

        protected void Refresh_Click(object sender, EventArgs e)
        {
            gvStudents.DataBind();
        }
    }
}