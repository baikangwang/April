#region

using System;

#endregion

namespace April.Entity.Base
{
    public interface IProperty
    {
        string Name { get; }
        Type Type { get; }
        string Label { get; }
        int Order { get; }
        bool Editable { get; }
        bool Listable { get; }
    }
}