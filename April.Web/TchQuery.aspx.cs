using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using April.Web.Base;
using April.Entity;
using April.Entity.Base;

namespace April.Web
{
    public partial class TchQuery : BasePage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            gvCourse.DataBind();

            if (string.IsNullOrEmpty(Id))
                ListStudent.Visible = false;
            else
            {
                ListStudent.Visible = true;
                gvStudent.DataBind();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Refresh_Click(object sender, EventArgs e)
        {
            gvCourse.DataBind();
        }

        protected void RefreshStd_Click(object sender, EventArgs e)
        {
            gvStudent.DataBind();
        }

        protected void Course_DataBinding(object sender, EventArgs e)
        {
            gvCourse.DataSource = BLL.CourseMgr.ListByTeacher(LoginUser.Id);
        }

        protected void Student_DataBinding(object sender, EventArgs e)
        {
            gvStudent.DataSource = BLL.SelectionMgr.ListStudentsByCourse(Id);
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
    }
}