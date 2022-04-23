using Core.Constants;
using Core.Entity.Abstract;
using FluentValidation;

namespace Entity.Dtos
{
    public class TagForCreateDto : IDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class TagForCreateDtoValidator : AbstractValidator<TagForCreateDto>
    {
        public TagForCreateDtoValidator()
        {
            RuleFor(x => x.Name).Length(1, 255).NotNull().WithName(Names.Name);
            
            RuleFor(x => x.Description).NotNull().WithName(Names.Description);

        }
    }
}