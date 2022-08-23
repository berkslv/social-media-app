using System.ComponentModel;
using Client.Models.Constants;
using Client.Models.Abstract;
using FluentValidation;

namespace Entity.Concrete
{
    public class UniversityForUpdateModel: IModel
    {
        public string Name { get; set; }
        
        public int City { get; set; }
        
        public int FoundationYear { get; set; }
    }

    public class UniversityForUpdateModelValidator : AbstractValidator<UniversityForUpdateModel>
    {
        public UniversityForUpdateModelValidator()
        {
            RuleFor(x => x.Name).Length(1, 255).NotNull().WithName(Names.Name);
            
            RuleFor(x => x.City).NotEmpty().LessThanOrEqualTo(81).GreaterThanOrEqualTo(1).WithName(Names.City);

            RuleFor(x => x.FoundationYear).NotNull().GreaterThanOrEqualTo(100).LessThanOrEqualTo(DateTime.Now.Year).WithName(Names.FoundationYear);
        }
    }
}