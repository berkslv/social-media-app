using System.ComponentModel.DataAnnotations.Schema;
using Core.Constants;
using Core.Entity.Abstract;
using FluentValidation;

namespace Entity.Concrete
{
    public class DepartmentForUpdateDto : IDto
    {
        public int FacultyId { get; set; }
        public int DepartmentCodeId { get; set; }

    }

    public class DepartmentForUpdateDtoValidator : AbstractValidator<DepartmentForUpdateDto>
    {
        public DepartmentForUpdateDtoValidator()
        {
            RuleFor(x => x.FacultyId).NotEmpty().WithName(Names.Faculty);

            RuleFor(x => x.DepartmentCodeId).NotEmpty().WithName(Names.DepartmentCode);
        }
    }
}