using Core.Entity.Abstract;
using Entity.Concrete;

namespace Entity.Dtos
{
    public class CommentDto : IGetDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public string Username { get; set; }
        public int PostId { get; set; }
        public int Like { get; set; }
        public int Dislike { get; set; }
        public long Created { get; set; }
    }
}