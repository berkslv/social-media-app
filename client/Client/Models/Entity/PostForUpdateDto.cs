using Client.Models.Constants;
using Client.Models.Abstract;
using FluentValidation;

namespace Client.Models
{
    public class PostForUpdateModel: IModel
    {
        public string Content { get; set; }
        public List<int> TagId { get; set; }
    }

    public class PostForUpdateModelValidator : AbstractValidator<PostForUpdateModel>
    {
        public PostForUpdateModelValidator()
        {
            RuleFor(x => x.Content).Length(1, 511).NotNull().WithName(Names.Content);
            
            RuleForEach(x => x.TagId).NotEmpty().GreaterThanOrEqualTo(1).WithName(Names.Tag);
        }
    }
}