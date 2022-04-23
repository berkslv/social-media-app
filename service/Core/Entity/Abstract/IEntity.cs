namespace Core.Entity.Abstract
{
    public interface IEntity
    {
        long Created { get; set; }
        long Updated { get; set; }
    }
}