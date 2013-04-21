using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using April.BLL;
using April.Entity;
using April.Entity.Base;

namespace April.Web.Base
{
    public abstract class MgrPage:Page
    {
        protected abstract bool IsEdit { get; }
    }

    public abstract class UserMgrPage : MgrPage
    {
        protected virtual string Id
        {
            get { return this.Request.QueryString["Id"]; }
        }

        protected abstract Role Role { get; }

        protected override bool IsEdit
        {
            get
            {
                return this.Request.QueryString["Mode"] != null &&
                       Convert.ToString(this.Request.QueryString["Mode"]) == "Edit";
            }
        }

        protected virtual IUser Item
        {
            get
            {
                if (string.IsNullOrEmpty(Id))
                    return null;
                try
                {
                    return UserMgr.Get(Id, Role);
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}