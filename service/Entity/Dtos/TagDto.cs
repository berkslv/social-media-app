using System.ComponentModel.DataAnnotations;
using Core.Entity.Abstract;

namespace Entity.Dtos
{
    public class TagDto : IGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}