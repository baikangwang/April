#region

using System;

#endregion

namespace April.Entity
{
    public interface IStudent : IUser
    {
        DateTime? Birthday { get; set; }
        string Address { get; set; }
        string Grade { get; set; }
    }
}