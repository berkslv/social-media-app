using System.ComponentModel.DataAnnotations;
using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class DepartmentCode : IEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        public List<Department> Departments { get; set; }
        
        public long Created { get; set; }
        
        public long Updated { get; set; }
    }
}