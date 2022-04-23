using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class Comment : IEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Content { get; set; }
        
        [Required]
        public int AuthorId { get; set; }
        
        public User Author { get; set; }
        
        [Required]
        public int PostId { get; set; }
        
        public Post Post { get; set; }
        
        public List<UserLikeComment> Likes { get; set; }
        
        public List<UserDislikeComment> Dislikes { get; set; }
        
        public long Created { get; set; }
        
        public long Updated { get; set; }
    }
}