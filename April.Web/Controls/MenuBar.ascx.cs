using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using April.Entity;
using April.Entity.Base;
using System.Web.UI.HtmlControls;

namespace April.Web.Controls
{
    public partial class MenuBar : System.Web.UI.UserControl
    {
        protected IDictionary<string,HtmlGenericControl> Links;
        

        protected void Page_Init(object sender, EventArgs e)
        {
            Links = new Dictionary<string, HtmlGenericControl>()
                      {
                          {"",itemLogout},
                          {"Default",itemLogin},
                          {"Home",itemHome},
                          {"StudentMgr",itemStudentMgr},
                          {"TeacherMgr",itemTeacherMgr},
                          {"CourseMgr",itemCourseMgr},
                          {"TchProfile",itemTchProfile},
                          {"TchQuery",itemTchQuery},
                          {"StdProfile",itemStdProfile},
                          {"StdQuery",itemStdQuery},
                          {"Select",itemSelect},
                          {"ScoreMgr",itemScoreMgr},
                          {"ScoreQuery",itemScoreQuery}
                      };
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            IUser user = HttpContext.Current.User == null ? null : HttpContext.Current.User as IUser;
            //string name = user == null ? string.Empty : user.Id;
            Role? role = user == null ? (Role?) null : user.Role;
            string page = this.Page.GetType().BaseType.Name;
            SetVisible(role);
            SetSelected(page);
            //lblUser.Text = user == null ? string.Empty : string.Format("你好！{0}({1})", name, role.Value.ToLabel());
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            HttpContext.Current.User = null;

            FormsAuthentication.SignOut();

            this.Response.Redirect("Default.aspx");
        }

        protected void SetSelected(string page)
        {
            foreach (string p in Links.Keys)
            {
                Links[p].Attributes["class"] = p == page ? "selected" : string.Empty;
            }
        }

        protected void SetVisible(Role? role)
        {
            foreach (HtmlGenericControl link in Links.Values)
            {
                link.Visible = false;
                link.Style["display"] = "none";
            }

            itemHome.Visible = true;

            if (role == null)
            {
                if (!(this.Page is Login))
                    itemLogin.Visible = true;
            }
            else
            {
                itemLogout.Visible = true;
                switch (role)
                {
                        case Role.Administrator:
                        itemStudentMgr.Visible = true;
                        itemTeacherMgr.Visible = true;
                        itemCourseMgr.Visible = true;
                        itemScoreMgr.Visible = true;
                        break;
                        case Role.Teacher:
                        itemTchProfile.Visible = true;
                        itemTchQuery.Visible = true;
                        break;
                        case Role.Student:
                        itemStdProfile.Visible = true;
                        itemStdQuery.Visible = true;
                        itemSelect.Visible = true;
                        itemScoreQuery.Visible = true;
                        break;
                    default:
                        break;
                }
            }

            foreach (HtmlGenericControl link in Links.Values)
            {
                if (link.Visible)
                    link.Style["display"] = "visible";
            }
        }

        protected void GoToPage(string linkId)
        {
            switch (linkId)
            {
                case "btnHome":
                    if (HttpContext.Current.User == null || HttpContext.Current.User as IUser == null)
                        Response.Redirect("~/Default.aspx");
                    else
                        Response.Redirect("~/Home.aspx");
                    break;
                case "btnStudentMgr":
                    Response.Redirect("~/StudentMgr.aspx");
                    break;
                case "btnTeacherMgr":
                    Response.Redirect("~/TeacherMgr.aspx");
                    break;
                case "btnCourseMgr":
                    Response.Redirect("~/CourseMgr.aspx");
                    break;
                case "btnTchProfile":
                    Response.Redirect("~/TchProfile.aspx");
                    break;
                case "btnTchQuery":
                    Response.Redirect("~/TchQuery.aspx");
                    break;
                case "btnStdProfile":
                    Response.Redirect("~/StdProfile.aspx");
                    break;
                case "btnStdQuery":
                    Response.Redirect("~/StdQuery.aspx");
                    break;
                case "btnSelect":
                    Response.Redirect("~/Select.aspx");
                    break;
                case "btnScoreMgr":
                    Response.Redirect("~/ScoreMgr.aspx");
                    break;
                case "btnScoreQuery":
                    Response.Redirect("~/ScoreQuery.aspx");
                    break;
                default:
                    Response.Redirect("~/Home.aspx");
                    break;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }

        protected void link_Click(object sender, EventArgs e)
        {
            LinkButton link = sender as LinkButton;
            GoToPage(link.ID);
        }
    }
}