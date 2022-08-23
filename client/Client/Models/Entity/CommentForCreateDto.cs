using Client.Models.Constants;
using Client.Models.Abstract;

using FluentValidation;

namespace Client.Models
{
    public class CommentForCreateModel: IModel
    {
        public string Content { get; set; }
        public int PostId { get; set; }
    }
    
    public class CommentForCreateModelValidator : AbstractValidator<CommentForCreateModel>
    {
        public CommentForCreateModelValidator()
        {
            RuleFor(x => x.Content).Length(1, 511).NotNull().WithName(Names.Content);
            
            RuleFor(x => x.PostId).GreaterThanOrEqualTo(1).NotEmpty().WithName(Names.Post);
        }
    }
}