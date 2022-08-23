using System.ComponentModel.DataAnnotations.Schema;
using Client.Models.Constants;
using Client.Models.Abstract;
using FluentValidation;

namespace Entity.Concrete
{
    public class DepartmentForUpdateModel: IModel
    {
        public int FacultyId { get; set; }
        public int DepartmentCodeId { get; set; }

    }

    public class DepartmentForUpdateModelValidator : AbstractValidator<DepartmentForUpdateModel>
    {
        public DepartmentForUpdateModelValidator()
        {
            RuleFor(x => x.FacultyId).NotEmpty().WithName(Names.Faculty);

            RuleFor(x => x.DepartmentCodeId).NotEmpty().WithName(Names.DepartmentCode);
        }
    }
}