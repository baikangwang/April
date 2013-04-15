using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using April.Entity.Base;

namespace April.Entity
{
    public interface IUser
    {
        string Name { get; set; }
        string Id { get; set; }
        Gender Gender { get; set; }
        string ContactNo { get; set; }
    }
}
