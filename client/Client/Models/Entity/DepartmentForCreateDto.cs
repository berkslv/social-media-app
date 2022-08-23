using System.ComponentModel.DataAnnotations.Schema;
using Client.Models.Constants;
using Client.Models.Abstract;
using FluentValidation;

namespace Entity.Concrete
{
    public class DepartmentForCreateModel: IModel
    {
        public int FacultyId { get; set; }
        public int DepartmentCodeId { get; set; }
    }

    public class DepartmentForCreateModelValidator : AbstractValidator<DepartmentForCreateModel>
    {
        public DepartmentForCreateModelValidator()
        {
            RuleFor(x => x.FacultyId).GreaterThanOrEqualTo(0).NotEmpty().WithName(Names.Faculty);

            RuleFor(x => x.DepartmentCodeId).GreaterThanOrEqualTo(0).NotEmpty().WithName(Names.DepartmentCode);
        }
    }
}