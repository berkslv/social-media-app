using Client.Models.Constants;
using Client.Models.Abstract;
using FluentValidation;

namespace Client.Models
{
    public class PostForCreateModel: IModel
    {
        public string Content { get; set; }
        public List<int> TagId { get; set; }
    }

    public class PostForCreateModelValidator : AbstractValidator<PostForCreateModel>
    {
        public PostForCreateModelValidator()
        {
            RuleFor(x => x.Content).Length(1, 511).NotNull().WithName(Names.Content);
            
            RuleForEach(x => x.TagId).NotEmpty().GreaterThanOrEqualTo(1).WithName(Names.Tag);
        }
    }
}