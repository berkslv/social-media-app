using Core.Entity.Abstract;

namespace Core.Entity.Concrete
{
    public class OperationClaim : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Created { get; set; }
        public long Updated { get; set; }
    }
}