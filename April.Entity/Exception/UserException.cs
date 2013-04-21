#region

using System;
using April.Entity.Base;

#endregion

namespace April.Entity.Exception
{
    public abstract class UserException : ApplicationException
    {
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

        public override string Message
        {
            get
            {
                string msg = "该" + Role.ToLabel() + "没有找到。";
                return msg;
            }
        }
    }

    public class UserInsertedException : UserException
    {
        public UserInsertedException(Role role)
            : base(role)
        {
        }

        public override string Message
        {
            get
            {
                string msg = "添加" + Role.ToLabel() + "失败。";
                return msg;
            }
        }
    }

    public class UserUpdatedException : UserException
    {
        public UserUpdatedException(Role role) : base(role)
        {
        }

        public override string Message
        {
            get { return "修改" + Role.ToLabel() + "失败。"; }
        }
    }

    public class UserDeleteException : UserException
    {
        public UserDeleteException(Role role) : base(role)
        {
        }

        public override string Message
        {
            get { return "删除" + Role.ToLabel() + "失败。"; }
        }
    }

    public class UserExistingException:UserException
    {
        public UserExistingException(Role role, string id) : base(role)
        {
            Id = id;
        }

        public string Id { get; private set; }

        public override string Message
        {
            get { return string.Format("该{0}[{1}]已存在。", Role.ToLabel(), Id); }
        }
    }
}