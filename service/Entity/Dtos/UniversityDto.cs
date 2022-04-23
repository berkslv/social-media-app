using Core.Entity.Abstract;
using Entity.Concrete;

namespace Entity.Dtos
{
    public class UniversityDto : IGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int FoundationYear { get; set; }
    }
}