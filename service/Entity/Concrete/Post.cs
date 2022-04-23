using System.ComponentModel.DataAnnotations;
using Core.Entity.Abstract;
using Core.Entity.Concrete;

namespace Entity.Concrete
{
    public class Post : IEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Content { get; set; }
        
        [Required]
        public int AuthorId { get; set; }
        
        public User Author { get; set; }
        
        public List<UserLikePost> Likes { get; set; }
        
        public List<UserDislikePost> Dislikes { get; set; }
        
        public List<Comment> Comments { get; set; }
        
        public List<PostHasTag> Tags { get; set; }
        
        public long Created { get; set; }
        
        public long Updated { get; set; }
    }
}