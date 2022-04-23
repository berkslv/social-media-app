using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using Core.Constants;
using Core.Utilities.Query;
using Entity.Concrete;
using FluentValidation;

namespace Entity.Filter
{
    public class DepartmentCodeFilter : FilterParameters
    {
        public string Name { get; set; }

        public void CreateQuery()
        {
            base.OrderBy = base.CreateSortWithType(typeof(DepartmentCode));
            base.Filter = CreateFilter();
        }

        protected string CreateFilter()
        {
            var filter = new List<String>();

            if (Name is not null)
            {
                filter.Add(String.Format("Name.Contains(\"{0}\")", Name));
            }

            return String.Join(" && ", filter.ToArray());;
        }
    }

    public class DepartmentCodeFilterValidator : AbstractValidator<DepartmentCodeFilter>
    {
        public DepartmentCodeFilterValidator()
        {
            RuleFor(x => x.Name).Length(1, 16).WithName(Names.Name);
        }
    }
}