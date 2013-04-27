﻿using System;
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
        protected virtual bool IsEdit
        {
            get
            {
                return this.Request.QueryString["Mode"] != null &&
                       Convert.ToString(this.Request.QueryString["Mode"]) == "Edit";
            }
        }

        protected virtual string Id
        {
            get { return this.Request.QueryString["Id"]; }
        }

        protected abstract IBaseObject Item { get; }

        protected abstract string Entity { get; }
    }

    public abstract class UserMgrPage : MgrPage
    {
        protected abstract Role Role { get; }

        private IBaseObject _item = null;
        
        protected override IBaseObject Item
        {
            get
            {
                if (string.IsNullOrEmpty(Id))
                {
                    _item = null;
                    return _item;
                }

                try
                {
                    if(_item==null)
                    _item= UserMgr.Get(Id, Role);
                }
                catch
                {
                    return _item=null;
                }

                return _item;
            }
        }

        protected override string Entity
        {
            get { return Role.ToEntity(); }
        }
    }
}