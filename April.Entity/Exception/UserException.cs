#region

using System;
using April.Entity.Base;

#endregion

namespace April.Entity.Exception
{
    public abstract class UserException : ApplicationException
    {
        protected UserException(string message, Role role) : base(message)
        {
            Role = role;
        }

        protected UserException(Role role)
        {
            Role = role;
        }

        public Role Role { get; private set; }
    }

    public class UserNotFoundException : UserException
    {
        public UserNotFoundException(Role role) : base(role)
        {
        }

        public UserNotFoundException(string message, Role role) : base(message, role)
        {
        }

        public override string Message
        {
            get
            {
                string msg = "该" + Role.ToLabel() + "没有找到。";
                return string.IsNullOrEmpty(base.Message) ? msg : base.Message + "。" + msg;
            }
        }
    }
}