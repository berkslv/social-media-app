using System.Linq.Expressions;
using Core.Constants;
using Core.Extensions;
using Core.Utilities.Query;
using Entity.Concrete;
using Entity.Enum;
using FluentValidation;

namespace Entity.Filter
{
    public class UniversityFilter : FilterParameters
    {
        public string Name { get; set; }

        public ECity? City { get; set; }

        public int? FoundationYear { get; set; }

        public void CreateQuery()
        {
            base.OrderBy = base.CreateSortWithType(typeof(University));
            base.Filter = CreateFilter();
        }

        protected string CreateFilter()
        {
            var filter = new List<String>();

            if (FoundationYear is not null)
            {
                filter.Add(String.Format("FoundationYear == {0}", FoundationYear));
            }

            if (Name is not null)
            {
                filter.Add(String.Format("Name.Contains(\"{0}\")", Name));
            }

            if (City is not null)
            {
                filter.Add(String.Format("City.Contains(\"{0}\")", City.ToString()));
            }

            return String.Join(" && ", filter.ToArray());;
        }
    }

    public class UniversityFilterValidator : AbstractValidator<UniversityFilter>
    {
        public UniversityFilterValidator()
        {
            RuleFor(x => x.Name).Length(1, 16).WithName(Names.Name);
            
            RuleFor(x => x.City).IsInEnum().WithName(Names.City);

            RuleFor(x => x.FoundationYear).GreaterThanOrEqualTo(100).LessThanOrEqualTo(DateTime.Now.Year).WithName(Names.FoundationYear);
        }
    }
}