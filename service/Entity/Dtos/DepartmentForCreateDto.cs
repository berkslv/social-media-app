using System.ComponentModel.DataAnnotations.Schema;
using Core.Constants;
using Core.Entity.Abstract;
using FluentValidation;

namespace Entity.Concrete
{
    public class DepartmentForCreateDto : IDto
    {
        public int FacultyId { get; set; }
        public int DepartmentCodeId { get; set; }
    }

    public class DepartmentForCreateDtoValidator : AbstractValidator<DepartmentForCreateDto>
    {
        public DepartmentForCreateDtoValidator()
        {
            RuleFor(x => x.FacultyId).GreaterThanOrEqualTo(0).NotEmpty().WithName(Names.Faculty);

            RuleFor(x => x.DepartmentCodeId).GreaterThanOrEqualTo(0).NotEmpty().WithName(Names.DepartmentCode);
        }
    }
}