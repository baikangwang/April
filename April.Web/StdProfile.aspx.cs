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
    public partial class StdProfile : ProfilePage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(Id))
            {
                lblMessage.Text = "个人信息读取失败，请重新进入";
                viewForm.Visible = false;
                editForm.Visible = false;
            }

            if (IsEdit)
            {
                viewForm.Visible = false;
                editForm.Visible = true;
                //lblPwd.Visible = false;
                //txtPwd.Visible = false;
                //ReqPwd.ValidationGroup = string.Empty;

                IStudent student = Item as IStudent;
                txtId.Text = student.Id;
                txtName.Text = student.Name;
                txtGrade.Text = student.Grade;
                txtAddress.Text = student.Address;
                txtContactNo.Text = student.ContactNo;
                txtBirthday.Text = student.Birthday == null
                                       ? string.Empty
                                       : student.Birthday.Value.ToString("yyyy年MM月dd日");
                ckbGender.Checked = student.Gender == Gender.Male;

                btnReset.Visible = true;
                btnReset.NavigateUrl = string.Format("~/StdProfile.aspx?Id={0}&Mode=Edit", Id);
            }
            else
            {
                editForm.Visible = false;
                viewForm.Visible = !string.IsNullOrEmpty(Id);
                if (!string.IsNullOrEmpty(Id) && Item as IStudent != null)
                {
                    //lblPwd.Visible = false;
                    //txtPwd.Visible = false;

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
                    lblvBirthday.Text = student.Birthday == null ? "无" : student.Birthday.Value.ToShortDateString();
                }
                btnEdit.NavigateUrl = string.Format("~/StdProfile.aspx?Id={0}&Mode=Edit", Id);
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {

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
            values.Add(Student.Birthday.Name,
                       string.IsNullOrEmpty(birthday)
                           ? (object) null
                           : Convert.ToDateTime(birthday.Replace("年", "-").Replace("月", "-").Replace("日", "")));
            values.Add(Student.Address.Name, string.IsNullOrEmpty(address) ? null : address);

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

        protected override Role Role
        {
            get { return Role.Student;}
        }
    }
}