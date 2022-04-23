using Core.Constants;
using Core.Entity.Abstract;
using FluentValidation;

namespace Entity.Dtos
{
    public class DepartmentCodeForUpdateDto : IDto
    {
        public string Name { get; set; }
    }


    public class DepartmentCodeForUpdateDtoValidator : AbstractValidator<DepartmentCodeForUpdateDto>
    {
        public DepartmentCodeForUpdateDtoValidator()
        {
            RuleFor(x => x.Name).Length(1, 255).NotNull().WithName(Names.Name);
        }
    }
}