using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using Core.Constants;
using Core.Extensions;
using Core.Utilities.Query;
using Entity.Concrete;
using FluentValidation;

namespace Entity.Filter
{
    public class FacultyFilter : FilterParameters
    {
        public string Name { get; set; }
        public double? Latitude { get; set; }
        public double? Altitude { get; set; }
        public string Address { get; set; }
        public int? UniversityId { get; set; }


        public void CreateQuery()
        {
            base.OrderBy = base.CreateSortWithType(typeof(Faculty));
            base.Filter = CreateFilter();
        }

        protected string CreateFilter()
        {
            var filter = new List<String>();

            if (Latitude is not null)
            {
                filter.Add(String.Format("Latitude == {0}", Latitude));
            }

            if (Altitude is not null)
            {
                filter.Add(String.Format("Altitude == {0}", Altitude));
            }

            if (Name is not null)
            {
                filter.Add(String.Format("Name.Contains(\"{0}\")", Name));
            }

            if (Address is not null)
            {
                filter.Add(String.Format("Address.Contains(\"{0}\")", Address));
            }

            if (UniversityId is not null)
            {
                filter.Add(String.Format("UniversityId == {0}", UniversityId));
            }

            return String.Join(" && ", filter.ToArray());;
        }
    }

    public class FacultyFilterValidator : AbstractValidator<FacultyFilter>
    {
        public FacultyFilterValidator()
        {
            RuleFor(x => x.Name).Length(1, 16).WithName(Names.Name);

            RuleFor(x => x.Latitude).GreaterThanOrEqualTo(0).WithName(Names.Latitude);

            RuleFor(x => x.Altitude).GreaterThanOrEqualTo(0).WithName(Names.Altitude);
            
            RuleFor(x => x.Address).Length(1, 16).WithName(Names.Address);

            RuleFor(x => x.UniversityId).GreaterThanOrEqualTo(0).WithName(Names.University);
        }
    }
}