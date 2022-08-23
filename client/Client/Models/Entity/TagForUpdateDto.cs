using Client.Models.Constants;
using Client.Models.Abstract;
using FluentValidation;

namespace Client.Models
{
    public class TagForUpdateModel: IModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class TagForUpdateModelValidator : AbstractValidator<TagForUpdateModel>
    {
        public TagForUpdateModelValidator()
        {
            RuleFor(x => x.Name).Length(1, 255).NotNull().WithName(Names.Name);
            
            RuleFor(x => x.Description).NotNull().WithName(Names.Description);
        }
    }
}