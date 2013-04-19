using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace April.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            //string adPath = "LDAP://" + txtDomain.Text;

            //var ldapAuth = new LdapAuthentication(adPath);

            //try
            //{
            //    if (ldapAuth.IsAuthenticated(txtDomain.Text, txtUsername.Text, txtPassword.Text))
            //    {
            //        //Generate custom data
            //        string userdate = txtDomain.Text + "|" + txtUsername.Text + "|" + txtPassword.Text + "|";

            //        #region Comment Code
            //        /*
            //    //HttpContext.Current.Session["User"] = new User()
            //    //                                          {
            //    //                                              Domain = txtDomain.Text,
            //    //                                              Password = txtPassword.Text,
            //    //                                              UserName = txtUsername.Text
            //    //                                          };
            //    */
            //        #endregion

            //        bool isCookiePersistent = chkPersist.Checked;

            //        //Obtain Authentication Ticket with custom data
            //        FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, txtUsername.Text,
            //                                                                             DateTime.Now,
            //                                                                             DateTime.Now.AddMinutes(30),
            //                                                                             isCookiePersistent, userdate, FormsAuthentication.FormsCookiePath);
            //        //Encrypt custom data
            //        string encryptiedTicket = FormsAuthentication.Encrypt(authTicket);

            //        //Generate authentication cookie which serves custom data in user local
            //        HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptiedTicket);

            //        if (isCookiePersistent)
            //        {
            //            authCookie.Expires = authTicket.Expiration;
            //            Response.Cookies.Add(authCookie);

            //        }

            //        #region Comment code
            //        /*
            //    HttpCookie appCookie = Request.Cookies["adAuthCookie"];

            //    if (isCookiePersistent)
            //    {
            //        if (appCookie == null)
            //        {
            //            appCookie = new HttpCookie("adAuthCookie");
            //        }

            //        appCookie.Values["UserName"] = txtUsername.Text;
            //        appCookie.Values["Password"] = txtPassword.Text;
            //        appCookie.Values["Domain"] = txtDomain.Text;

            //        authCookie.Expires = DateTime.Now.AddMonths(1);
            //        Response.Cookies.Set(authCookie);

            //    }
            //    else
            //    {
            //        if (authCookie != null)
            //        {
            //        authCookie.Expires.AddDays(-1);
            //        Response.Cookies.Set(authCookie);
            //        }
            //    }
            //     */
            //        #endregion

            //        Response.Redirect(FormsAuthentication.GetRedirectUrl(txtUsername.Text, false));
            //    }
            //    else
            //    {
            //        errorLabel.Text = "Authentication did not succeed. Check user name and password.";
            //    }
            //}
            //catch (Exception ex)
            //{

            //    errorLabel.Text = "Error authenticating. " + ex.Message;
            //}
        }


    }
}
