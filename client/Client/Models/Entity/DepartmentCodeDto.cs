using Client.Models.Abstract;

namespace Client.Models
{
    public class DepartmentCodeModel: IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}