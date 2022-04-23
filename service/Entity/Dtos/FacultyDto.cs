using Core.Entity.Abstract;
using Entity.Concrete;

namespace Entity.Dtos
{
    public class FacultyDto : IGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Altitude { get; set; }
        public string Address { get; set; }
        public int UniversityId { get; set; }
    }
}