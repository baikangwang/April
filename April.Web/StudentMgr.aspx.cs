using System;
using System.Collections.Generic;
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
                    lblPwd.Visible = true;
                    txtPwd.Visible = true;
                    ReqPwd.ValidationGroup = "save";
                    
                    txtId.Text = string.Empty;
                    txtName.Text = string.Empty;
                    txtGrade.Text = string.Empty;
                    txtContactNo.Text = string.Empty;
                    txtAddress.Text = string.Empty;
                    txtPwd.Text = string.Empty;
                    ckbGender.Checked = true; // Gender.Male
                    txtBirthday.Text = string.Empty;

                    btnReset.Visible = false;
                }
                else
                {
                    lblPwd.Visible = false;
                    txtPwd.Visible = false;
                    ReqPwd.ValidationGroup = string.Empty;

                    IStudent student = Item as IStudent;
                    txtId.Text = student.Id;
                    txtName.Text = student.Name;
                    txtGrade.Text = student.Grade;
                    txtAddress.Text = student.Address;
                    txtContactNo.Text = student.ContactNo;
                    txtBirthday.Text = student.Birthday == null ? string.Empty : student.Birthday.Value.ToString("yyyy年MM月dd日");
                    ckbGender.Checked = student.Gender == Gender.Male;

                    btnReset.Visible = true;
                    btnReset.NavigateUrl = string.Format("~/StudentMgr.aspx?Id={0}&Mode=Edit", Id);
                }
            }
            else
            {
                editForm.Visible = false;
                viewForm.Visible = !string.IsNullOrEmpty(Id) && Item as IStudent != null;
                if (!string.IsNullOrEmpty(Id) && Item as IStudent != null)
                {
                    lblvPwd.Visible = false;
                    Label8.Visible = false;

                    IStudent student = Item as IStudent;
                    lblvId.Text = string.IsNullOrEmpty(student.Id) ? "无" : student.Id;
                    lblvName.Text = string.IsNullOrEmpty(student.Name) ? "无" : student.Name;
                    lblvGrade.Text = string.IsNullOrEmpty(student.Grade) ? "无" : student.Grade;
                    lblvAddress.Text = string.IsNullOrEmpty(student.Address) ? "无" : student.Address;
                    lblvContactNo.Text = string.IsNullOrEmpty(student.ContactNo) ? "无" : student.ContactNo;
                    lblvGender.Style.Add("background",
                                         student.Gender == Gender.Male
                                             ? "url('../images/icons/male.png\') no-repeat center transparent"
                                             : "url('../images/icons/female.png') no-repeat center transparent");
                    lblvBirthday.Text = student.Birthday == null ? "无" : student.Birthday.Value.ToString("yyyy年MM月dd日");
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

            string id = txtId.Text.Trim();
            string name = txtName.Text.Trim();
            string grade = txtGrade.Text.Trim();
            Gender gender = ckbGender.Checked ? Gender.Male : Gender.Female;
            string contactNo = txtContactNo.Text.Trim();
            string birthday = txtBirthday.Text.Trim();
            string address = txtAddress.Text.Trim();


            values.Add(Student.Id.Name, id);
            values.Add(Student.Name.Name, name);
            values.Add(Student.Grade.Name, string.IsNullOrEmpty(grade) ? null : grade);
            values.Add(Student.Gender.Name, gender);
            values.Add(Student.ContactNo.Name, string.IsNullOrEmpty(contactNo) ? null : contactNo);
            
            if (string.IsNullOrEmpty(birthday))
                values.Add(Student.Birthday.Name, null);
            else
            {
                string[] date = birthday.Replace("年", "-").Replace("月", "-").Replace("日", "-").Split(
                    new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
                values.Add(Student.Birthday.Name, new DateTime(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2])));
            }
            
            if (string.IsNullOrEmpty(Id))
                values.Add(Student.Password.Name, txtPwd.Text.Trim());
            else
                values.Add("oId",Id);

            try
            {
                if (!string.IsNullOrEmpty(Id))
                {
                    UserMgr.Update(Role, values);
                    lblMessage.Text = "修改"+EntityLabel+"成功！";
                }
                else
                {
                    if(UserMgr.IsExisting(Role,Id))
                        throw new ExistingBaseObjException(EntityLabel,id);

                    UserMgr.Insert(Role, values);
                    lblMessage.Text = "添加" + EntityLabel + "成功！";
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
                    lblMessage.Text = "删除" + EntityLabel + "成功！";
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

        protected void Gender_DataBinding(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            if (lbl == null) return;
            GridViewRow row = lbl.NamingContainer as GridViewRow;
            if (row == null) return;
            IUser user = row.DataItem as IUser;
            if (user == null) return;
            lbl.Style.Add("background",
                                 user.Gender == Gender.Male
                                     ? "url('../images/icons/male.png\') no-repeat center transparent"
                                     : "url('../images/icons/female.png') no-repeat center transparent");
            lbl.Text = " ";
        }

        protected void gvStudents_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvStudents.PageIndex = e.NewPageIndex;
            gvStudents.DataBind();
        }
    }
}