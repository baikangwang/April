using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using April.Entity.Base;
using April.Web.Base;

namespace April.Web
{
    public partial class Home : BasePage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (LoginUser == null)
                this.@default.Visible = true;
            else
            {
                switch (LoginUser.Role)
                {
                    case Role.Administrator:
                        this.admin.Visible = true;
                        break;
                    case Role.Teacher:
                        this.teacher.Visible = true;
                        break;
                    case Role.Student:
                        this.student.Visible = true;
                        break;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }

}