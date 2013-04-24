#region

using April.Entity.Base;

#endregion

namespace April.Entity
{
    public interface ICourse : IBaseObject
    {
        ITeacher Teacher { get; set; }
        int Hours { get; set; }
        int Credit { get; set; }
        int Period { get; set; }
        string Location { get; set; }
        int MaxCapacity { get; set; }
    }
}