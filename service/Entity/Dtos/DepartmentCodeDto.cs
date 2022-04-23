using Core.Entity.Abstract;

namespace Entity.Dtos
{
    public class DepartmentCodeDto : IGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}