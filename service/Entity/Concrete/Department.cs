using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class Department : IEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [ForeignKey("Faculty")]
        public int FacultyId { get; set; }
        
        public Faculty Faculty { get; set; }

        [Required]
        [ForeignKey("DepartmentCode")]
        public int DepartmentCodeId { get; set; }
        
        public DepartmentCode DepartmentCode { get; set; }
        
        public List<User> Users { get; set; }

        public long Created { get; set; }
        
        public long Updated { get; set; }
    }
}