using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using April.Entity;
using April.Entity.Base;

namespace April.Web.Base
{
    public abstract class BasePage : Page
    {
        public IUser LoginUser
        {
            get { return HttpContext.Current.User as IUser; }
        }

        protected virtual string Id
        {
            get { return this.Request.QueryString["Id"]; }
        }
    }
}