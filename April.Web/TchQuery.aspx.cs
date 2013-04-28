using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using April.Web.Base;

namespace April.Web
{
    public partial class TchQuery : BasePage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            gvCourse.DataBind();

            if (string.IsNullOrEmpty(Id))
                gvStudent.Visible = false;
            else
            {
                gvStudent.Visible = true;
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
            gvStudent.DataSource = BLL.SelectionMgr.ListByCourse(Id);
        }
    }
}