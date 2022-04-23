using System.ComponentModel.DataAnnotations;
using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class Tag : IEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public List<PostHasTag> Posts { get; set; }
        
        public long Created { get; set; }
        
        public long Updated { get; set; }
    }
}