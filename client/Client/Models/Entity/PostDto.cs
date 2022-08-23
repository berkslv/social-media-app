using System.ComponentModel.DataAnnotations;
using Client.Models.Abstract;


namespace Client.Models
{
    public class PostModel: IModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Like { get; set; }
        public int Dislike { get; set; }
        public int AuthorId { get; set; }
        public string Username { get; set; }
        public List<int> TagId { get; set; }
        public long Created { get; set; }
    }
}