#region

using April.Entity.Base;

#endregion

namespace April.Entity
{
    public interface ICourse : IBaseObject
    {
        int Id { get; set; }
        ITeacher Teacher { get; set; }
        int Hours { get; set; }
        int Credit { get; set; }
        int Period { get; set; }
        string Location { get; set; }
        int MaxCapacity { get; set; }
    }
}