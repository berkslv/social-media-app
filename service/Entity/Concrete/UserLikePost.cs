using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class UserLikePost : IEntityRelation
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        public long Created { get; set; }
        public long Updated { get; set; }
    }
}