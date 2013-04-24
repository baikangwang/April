using April.Entity.Base;

namespace April.Entity
{
    public interface ISelection:IBaseObject
    {
        IStudent Student { get; set; }
        ICourse Course { get; set; }
    }
}