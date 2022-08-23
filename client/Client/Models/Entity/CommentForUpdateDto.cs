using Client.Models.Constants;
using Client.Models.Abstract;
using FluentValidation;

namespace Client.Models
{
    public class CommentForUpdateModel : IModel
    {
        public string Content { get; set; }
        public int PostId { get; set; }
    }

    public class CommentForUpdateModelValidator : AbstractValidator<CommentForUpdateModel>
    {
        public CommentForUpdateModelValidator()
        {
            RuleFor(x => x.Content).Length(1, 511).NotNull().WithName(Names.Content);

            RuleFor(x => x.PostId).GreaterThanOrEqualTo(1).NotEmpty().WithName(Names.Post);
        }
    }
}