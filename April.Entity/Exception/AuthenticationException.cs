using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace April.Entity.Exception
{
    public abstract class AuthenticationException:ApplicationException
    {
        protected AuthenticationException():base(){}

        protected AuthenticationException(string message):base(message){}
    }

    public class TimeoutAuthException:AuthenticationException
    {
        public override string Message
        {
            get
            {
                string msg = "登录超时，请重新登录。";

                return string.IsNullOrEmpty(base.Message) ? msg : base.Message + "。" + msg;
            }
        }
    }

    public class FailAuthException : AuthenticationException
    {
        public override string Message
        {
            get
            {
                string msg = "学（工）号或密码不正确。";

                return string.IsNullOrEmpty(base.Message) ? msg : base.Message + "。" + msg;
            }
        }
    }
}
