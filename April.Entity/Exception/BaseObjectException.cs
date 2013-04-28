using System;

namespace April.Entity.Exception
{
    public abstract class BaseObjectException:ApplicationException
    {
        public string Entity { get; private set; }
        public string Identity { get; private set; }

        protected abstract string Action { get; }

        protected BaseObjectException(string entity, string identity = null)
        {
            Entity = entity;
            Identity = identity;
        }

        public override string Message
        {
            get
            {
                string identity = string.IsNullOrEmpty(Identity) ? "" : "[" + Identity + "]";
                return string.Format("{0}{1}{2}失败!", Action, Entity, identity);
            }
        }
    }

    public class InsertBaseObjException:BaseObjectException
    {
        public InsertBaseObjException(string entity, string identity)
            : base(entity, identity)
        {
        }

        protected override string Action
        {
            get { return "添加"; }
        }
    }

    public class UpdateBaseObjException : BaseObjectException
    {
        public UpdateBaseObjException(string entity, string identity) : base(entity, identity)
        {
        }

        protected override string Action
        {
            get { return "修改"; }
        }
    }

    public class DeleteBaseObjException : BaseObjectException
    {
        public DeleteBaseObjException(string entity, string identity)
            : base(entity, identity)
        {
        }

        protected override string Action
        {
            get { return "删除"; }
        }
    }

    public class NotFoundBaseObjException : BaseObjectException
    {
        public NotFoundBaseObjException(string entity, string identity) : base(entity, identity)
        {
        }

        protected override string Action
        {
            get { return string.Empty; }
        }

        public override string Message
        {
            get
            {
                string identity = string.IsNullOrEmpty(Identity) ? "" : "[" + Identity + "]";
                return string.Format("没有找到{0}{1}。", Entity, identity);
            }
        }
    }

    public class ExistingBaseObjException : BaseObjectException
    {
        public ExistingBaseObjException(string entity, string identity) : base(entity, identity)
        {

        }

        protected override string Action
        {
            get { return string.Empty; }
        }

        public override string Message
        {
            get
            {
                string identity = string.IsNullOrEmpty(Identity) ? "" : "[" + Identity + "]";
                return string.Format("{0}{1}已选择。", Entity, identity);
            }
        }
    }
}
