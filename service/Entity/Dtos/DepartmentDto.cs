using System.ComponentModel.DataAnnotations.Schema;
using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class DepartmentDto : IGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FacultyId { get; set; }
        public int DepartmentCodeId { get; set; }
    }
}