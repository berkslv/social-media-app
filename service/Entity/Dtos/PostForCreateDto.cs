using Core.Constants;
using Core.Entity.Abstract;
using FluentValidation;

namespace Entity.Dtos
{
    public class PostForCreateDto : IDto
    {
        public string Content { get; set; }
        public List<int> TagId { get; set; }
    }

    public class PostForCreateDtoValidator : AbstractValidator<PostForCreateDto>
    {
        public PostForCreateDtoValidator()
        {
            RuleFor(x => x.Content).Length(1, 511).NotNull().WithName(Names.Content);
            
            RuleForEach(x => x.TagId).NotEmpty().GreaterThanOrEqualTo(1).WithName(Names.Tag);
        }
    }
}