using Core.Entity.Abstract;

namespace Core.Entity.Concrete
{
    public class UserOperationClaim : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
        public long Created { get; set; }
        public long Updated { get; set; }
    }
}