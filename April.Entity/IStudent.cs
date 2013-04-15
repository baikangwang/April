using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace April.Entity
{
    public interface IStudent:IUser
    {
        DateTime Brithday { get; set; }
        string Address { get; set; }
    }
}
