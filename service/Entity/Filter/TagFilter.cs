using System.Linq.Expressions;
using Core.Constants;
using Core.Extensions;
using Core.Utilities.Query;
using Entity.Concrete;
using FluentValidation;

namespace Entity.Filter
{
    public class TagFilter : FilterParameters
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public void CreateQuery()
        {
            base.OrderBy = base.CreateSortWithType(typeof(Tag));
            base.Filter = CreateFilter();
        }

        protected string CreateFilter()
        {
            var filter = new List<String>();

            if (Description is not null)
            {
                filter.Add(String.Format("Description == {0}", Description));
            }

            if (Name is not null)
            {
                filter.Add(String.Format("Name.Contains(\"{0}\")", Name));
            }

            return String.Join(" && ", filter.ToArray());;
        }

    }

    public class TagFilterValidator : AbstractValidator<TagFilter>
    {
        public TagFilterValidator()
        {
            RuleFor(x => x.Name).Length(1, 16).WithName(Names.Name);

            RuleFor(x => x.Description).Length(1, 16).WithName(Names.Description);
        }
    }
}