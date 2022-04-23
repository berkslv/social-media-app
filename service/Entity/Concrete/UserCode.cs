using System.ComponentModel.DataAnnotations.Schema;
using Core.Entity.Abstract;
using Core.Entity.Concrete;

namespace Entity.Concrete
{
    public class UserCode : IEntity
    {
        public int UserCodeId { get; set; }
        public string Code { get; set; }
        
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        
        public long Created { get; set; }
        public long Updated { get; set; }
    }
}