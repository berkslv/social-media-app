using System.ComponentModel.DataAnnotations.Schema;
using Client.Models.Abstract;

namespace Entity.Concrete
{
    public class DepartmentModel: IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FacultyId { get; set; }
        public int DepartmentCodeId { get; set; }
    }
}