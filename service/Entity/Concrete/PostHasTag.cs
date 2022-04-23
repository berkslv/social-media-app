using System.ComponentModel.DataAnnotations;
using Core.Entity.Abstract;
using Core.Entity.Concrete;

namespace Entity.Concrete
{
    public class PostHasTag : IEntityRelation
    {
        public int PostId { get; set; }
        public Post Post { get; set; }
        
        public int TagId { get; set; }
        public Tag Tag { get; set; }
        
        public long Created { get; set; }
        
        public long Updated { get; set; }
    }
}