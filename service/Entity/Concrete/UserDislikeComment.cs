using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class UserDislikeComment : IEntityRelation
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int CommentId { get; set; }
        public Comment Comment { get; set; }
        public long Created { get; set; }
        public long Updated { get; set; }
    }
}