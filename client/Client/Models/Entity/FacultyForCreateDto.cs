using Client.Models.Constants;
using Client.Models.Abstract;
using FluentValidation;

namespace Client.Models
{
    public class FacultyForCreateModel: IModel
    {
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Altitude { get; set; }
        public string Address { get; set; }
        public int UniversityId { get; set; }
    }

    public class FacultyForCreateModelValidator : AbstractValidator<FacultyForCreateModel>
    {
        public FacultyForCreateModelValidator()
        {
            RuleFor(x => x.Name).Length(1, 255).NotNull().WithName(Names.Name);

            RuleFor(x => x.Latitude).GreaterThanOrEqualTo(0).NotEmpty().WithName(Names.Latitude);

            RuleFor(x => x.Altitude).GreaterThanOrEqualTo(0).NotEmpty().WithName(Names.Altitude);
            
            RuleFor(x => x.Address).Length(1, 255).NotNull().WithName(Names.Address);

            RuleFor(x => x.UniversityId).NotEmpty().WithName(Names.University);
        }
    }
}