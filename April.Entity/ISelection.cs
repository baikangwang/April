using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace April.Entity
{
    public interface ISelection
    {
        IStudent Student { get; set; }
        ICourse Course { get; set; }
    }
}
