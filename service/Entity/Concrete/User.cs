using System.ComponentModel.DataAnnotations.Schema;
using Core.Entity.Concrete;

namespace Entity.Concrete
{
    public class User : UserBase
    {
        public string Role { get; set; }

        [ForeignKey("University")]
        public int? UniversityId { get; set; }
        public University University { get; set; }
        
        [ForeignKey("Faculty")]
        public int? FacultyId { get; set; }
        public Faculty Faculty { get; set; }

        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }

        public List<Post> Posts { get; set; }
        public List<UserLikePost> LikedPosts { get; set; }
        public List<UserDislikePost> DislikedPosts { get; set; }

        public List<Comment> Comments { get; set; }
        public List<UserLikeComment> LikedComments { get; set; }
        public List<UserDislikeComment> DislikedComments { get; set; }
    }

}