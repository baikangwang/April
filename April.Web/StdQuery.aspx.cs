using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using April.BLL;
using April.Entity;
using April.Entity.Base;
using April.Web.Base;

namespace April.Web
{
    public partial class StdQuery : BasePage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            gvCourses.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Refresh_Click(object sender, EventArgs e)
        {
            gvCourses.DataBind();
        }

        protected void gvCourses_DataBinding(object sender, EventArgs e)
        {
            gvCourses.DataSource = SelectionMgr.ListByStudent(LoginUser.Id);
        }

        protected void gvCourses_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                string id = Convert.ToString(e.CommandArgument);

                try
                {
                    ISelection select = SelectionMgr.Get(id, LoginUser.Id);
                    if (select == null)
                    {
                        lblMessage.Text = "选课已取消！";
                        return;
                    }
                    BLL.SelectionMgr.Delete(select.Id);
                    lblMessage.Text = "选课取消成功！";
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                }
            }
        }

        //protected override string Id
        //{
        //    get { return LoginUser == null ? string.Empty : LoginUser.Id; }
        //}

        protected void gvCourses_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            gvCourses.DataBind();
        }
    }
}