using Core.Constants;
using Core.Entity.Abstract;
using FluentValidation;

namespace Entity.Dtos
{
    public class DepartmentCodeForCreateDto : IDto
    {
        public string Name { get; set; }
    }

    public class DepartmentCodeForCreateDtoValidator : AbstractValidator<DepartmentCodeForCreateDto>
    {
        public DepartmentCodeForCreateDtoValidator()
        {
            RuleFor(x => x.Name).Length(1, 255).NotNull().WithName(Names.Name);
        }
    }
}