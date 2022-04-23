using Core.Constants;
using Core.Entity.Abstract;
using Entity.Concrete;
using FluentValidation;

namespace Entity.Dtos
{
    public class CommentForCreateDto : IDto
    {
        public string Content { get; set; }
        public int PostId { get; set; }
    }
    
    public class CommentForCreateDtoValidator : AbstractValidator<CommentForCreateDto>
    {
        public CommentForCreateDtoValidator()
        {
            RuleFor(x => x.Content).Length(1, 511).NotNull().WithName(Names.Content);
            
            RuleFor(x => x.PostId).GreaterThanOrEqualTo(1).NotEmpty().WithName(Names.Post);
        }
    }
}