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
    public partial class TchProfile : ProfilePage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Id))
            {
                lblMessage.Text = "个人信息读取失败，请重新进入";
                viewForm.Visible = false;
                editForm.Visible = false;
            }
            
            if (IsEdit)
            {
                viewForm.Visible = false;
                editForm.Visible = true;
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
                btnReset.NavigateUrl = string.Format("~/TchProfile.aspx?Id={0}&Mode=Edit", Id);
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
                    lblvGender.Style.Add("background",
                                         teacher.Gender == Gender.Male
                                             ? "url('../images/icons/male.png\') no-repeat center transparent"
                                             : "url('../images/icons/female.png') no-repeat center transparent");
                }
                btnEdit.NavigateUrl = string.Format("~/TchProfile.aspx?Id={0}&Mode=Edit", Id);
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override Role Role
        {
            get { return Role.Teacher; }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            IDictionary<string, object> values = new Dictionary<string, object>();

            string id = txtId.Text.Trim();
            string name = txtName.Text.Trim();
            Gender gender = ckbGender.Checked ? Gender.Male : Gender.Female;
            string contactNo = txtContactNo.Text.Trim();
            string title = txtTitle.Text.Trim();

            values.Add(Teacher.Id.Name, id);
            values.Add(Teacher.Name.Name, name);
            values.Add(Teacher.Title.Name, string.IsNullOrEmpty(title) ? null : title);
            values.Add(Teacher.Gender.Name, gender);
            values.Add(Teacher.ContactNo.Name, string.IsNullOrEmpty(contactNo) ? null : contactNo);

            values.Add("oId", Id);

            try
            {
                UserMgr.Update(Role, values);
                lblMessage.Text = "修改" + EntityLabel + "成功！";
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        protected override string Id
        {
            get { return LoginUser == null ? string.Empty : LoginUser.Id; }
        }
    }
}