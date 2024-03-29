using System.ComponentModel.DataAnnotations;
using Core.Entity.Abstract;
using Entity.Concrete;

namespace Entity.Dtos
{
    public class PostDto : IGetDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Like { get; set; }
        public int Dislike { get; set; }
        public int AuthorId { get; set; }
        public string AuthorUniversity { get; set; }
        public string AuthorFaculty { get; set; }
        public string AuthorDeparment { get; set; }
        public string Username { get; set; }
        public List<int> TagId { get; set; }
        public List<string> Tags { get; set; }
        public long Created { get; set; }
    }
}