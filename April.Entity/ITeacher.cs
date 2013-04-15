using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace April.Entity
{
    public interface ITeacher:IUser
    {
        string Title { get; set; }
    }
}
