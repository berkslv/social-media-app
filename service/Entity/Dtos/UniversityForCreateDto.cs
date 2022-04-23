using Core.Constants;
using Core.Entity.Abstract;
using FluentValidation;

namespace Entity.Dtos
{
    public class UniversityForCreateDto : IDto
    {
        public string Name { get; set; }
        
        public int City { get; set; }
        
        public int FoundationYear { get; set; }
        
        public List<int> Faculties { get; set; }
    }

    public class UniversityForCreateDtoValidator : AbstractValidator<UniversityForCreateDto>
    {
        public UniversityForCreateDtoValidator()
        {
            RuleFor(x => x.Name).Length(1, 255).NotNull().WithName(Names.Name);
            
            RuleFor(x => x.City).NotEmpty().LessThanOrEqualTo(81).GreaterThanOrEqualTo(1).WithName(Names.City);

            RuleFor(x => x.FoundationYear).NotNull().GreaterThanOrEqualTo(100).LessThanOrEqualTo(DateTime.Now.Year).WithName(Names.FoundationYear);
        }
    }
}