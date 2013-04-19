#region

using System;
using April.Entity.Base;

#endregion

namespace April.EntityImpl.Base
{
    public class Property : IProperty
    {
        private readonly bool _editable;
        private readonly int _index;
        private readonly string _label;
        private readonly bool _listable;
        private readonly string _name;
        private readonly Type _type;

        public Property(string name, string label, Type type, int index, bool editable = true, bool listable = true)
        {
            _name = name;
            _label = label;
            _type = type;
            _index = index;
            _editable = editable;
            _listable = listable;
        }

        #region IProperty Members

        public string Name
        {
            get { return _name; }
        }

        public Type Type
        {
            get { return _type; }
        }

        public string Label
        {
            get { return _label; }
        }

        public int Order
        {
            get { return _index; }
        }

        public bool Editable
        {
            get { return _editable; }
        }

        public bool Listable
        {
            get { return _listable; }
        }

        #endregion
    }
}