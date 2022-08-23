using Client.Models.Abstract;

namespace Client.Models
{
    public class CommentModel: IModel
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