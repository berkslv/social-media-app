using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using Core.Constants;
using Core.Extensions;
using Core.Utilities.Query;
using Entity.Concrete;
using FluentValidation;

namespace Entity.Filter
{
    public class DepartmentFilter : FilterParameters
    {
        public int? FacultyId { get; set; }
        
        public int? DepartmentCodeId { get; set; }

        public void CreateQuery()
        {
            base.OrderBy = base.CreateSortWithType(typeof(Department));
            base.Filter = CreateFilter();
        }

        protected string CreateFilter()
        {
            var filter = new List<String>();

            if (FacultyId is not null)
            {
                filter.Add(String.Format("FacultyId == {0}", FacultyId));
            }

            if (DepartmentCodeId is not null)
            {
                filter.Add(String.Format("DepartmentCodeId == {0}", DepartmentCodeId));
            }

            return String.Join(" && ", filter.ToArray());;
        }
    }

    public class DepartmentFilterValidator : AbstractValidator<DepartmentFilter>
    {
        public DepartmentFilterValidator()
        {
            RuleFor(x => x.FacultyId).GreaterThanOrEqualTo(0).WithName(Names.Faculty);

            RuleFor(x => x.DepartmentCodeId).GreaterThanOrEqualTo(0).WithName(Names.DepartmentCode);
        }
    }
}