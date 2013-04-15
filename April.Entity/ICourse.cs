using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace April.Entity
{
    public interface ICourse
    {
        int Id { get; set; }
        string Name { get; set; }
        ITeacher Teacher { get; set; }
        int Hours { get; set; }
        int Credit { get; set; }
        int Period { get; set; }
        string Location { get; set; }
        int MaxCapacity { get; set; }
    }
}
