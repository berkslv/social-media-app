using System.ComponentModel.DataAnnotations;
using Client.Models.Abstract;

namespace Client.Models
{
    public class TagModel: IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}