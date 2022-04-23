using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class Faculty : IEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public double Latitude { get; set; }
        
        [Required]
        public double Altitude { get; set; }
        
        [Required]
        public string Address { get; set; }

        [Required]
        [ForeignKey("University")]
        public int UniversityId { get; set; }
        
        public University University { get; set; }

        public List<Department> Departments { get; set; }

        public List<User> Users { get; set; }

        public long Created { get; set; }
        
        public long Updated { get; set; }

    }
}