using Client.Models.Constants;
using Client.Models.Abstract;
using FluentValidation;

namespace Client.Models
{
    public class TagForCreateModel: IModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class TagForCreateModelValidator : AbstractValidator<TagForCreateModel>
    {
        public TagForCreateModelValidator()
        {
            RuleFor(x => x.Name).Length(1, 255).NotNull().WithName(Names.Name);
            
            RuleFor(x => x.Description).NotNull().WithName(Names.Description);

        }
    }
}