#region

using System;

#endregion

namespace April.Entity.Exception
{
    public abstract class AuthenticationException : ApplicationException
    {
    }

    public class TimeoutAuthException : AuthenticationException
    {
        public override string Message
        {
            get
            {
                string msg = "登录超时，请重新登录。";

                return msg;
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

                return msg;
            }
        }
    }
}