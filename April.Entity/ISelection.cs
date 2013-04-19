namespace April.Entity
{
    public interface ISelection
    {
        IStudent Student { get; set; }
        ICourse Course { get; set; }
    }
}