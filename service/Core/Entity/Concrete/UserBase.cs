using System.ComponentModel.DataAnnotations;
using Core.Entity.Abstract;

namespace Core.Entity.Concrete
{
    public class UserBase : IEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Username { get; set; }
        
        public byte[] PasswordSalt { get; set; }
        
        public byte[] PasswordHash { get; set; }
        
        public bool Status { get; set; }
        
        public long Created { get; set; } // unix timestamp
        
        public long Updated { get; set; } // unix timestamp
    }
}