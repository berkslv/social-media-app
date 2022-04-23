using System.ComponentModel.DataAnnotations;
using Core.Entity.Abstract;
using FluentValidation;

namespace Entity.Concrete
{
    public class University : IEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string City { get; set; }
        
        [Required]
        public int FoundationYear { get; set; }
        
        public List<Faculty> Faculties { get; set; }
        
        public List<User> Users { get; set; }
        
        public long Created { get; set; }
        
        public long Updated { get; set; }
    }

}