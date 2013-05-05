using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using April.BLL;
using April.Entity;
using April.Entity.Base;
using April.Entity.Exception;

namespace April.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string id = txtId.Value;
            string pwd = txtPwd.Value;
            Role role = (Role) int.Parse(dllRole.SelectedValue);
            bool isRemember = ckbRememder.Checked;

            try
            {
                IUser user = UserMgr.Authenticate(id, pwd, role);
                if(user==null)
                    throw new FailAuthException();

                HttpContext.Current.User = user;

                string data = id + "|" + (int) role;

                //Obtain Authentication Ticket with custom data
                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, id,
                                                                                     DateTime.Now,
                                                                                     isRemember? DateTime.Now.AddMinutes(30):DateTime.Now.AddMonths(1),
                                                                                     isRemember, data, FormsAuthentication.FormsCookiePath);
                //Encrypt custom data
                string encryptiedTicket = FormsAuthentication.Encrypt(authTicket);

                //Generate authentication cookie which serves custom data in user local
                HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptiedTicket)
                                            {Expires = authTicket.Expiration};

                Response.Cookies.Add(authCookie);

                Response.Redirect("~/Home.aspx");
            }

            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }


    }
}
