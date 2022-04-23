using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Core.Constants;
using Core.Extensions;
using Core.Utilities.Query;
using Entity.Concrete;
using FluentValidation;

namespace Entity.Filter
{

    
    public class PostFilter : FilterParameters
    {
        public string Content { get; set; }
        
        public int? AuthorId { get; set; }

        public int? UniversityId { get; set; }

        public int? FacultyId { get; set; }

        public int? DepartmentId { get; set; }

        public int? DepartmentCodeId { get; set; }

        public int? TagId { get; set; }


        public void CreateQuery()
        {
            base.OrderBy = base.CreateSortWithType(typeof(Post));
            base.Filter = CreateFilter();
        }

        protected string CreateFilter()
        {
            var filter = new List<String>();

            if (AuthorId is not null)
            {
                filter.Add(String.Format("AuthorId == {0}", AuthorId));
            }

            if (UniversityId is not null)
            {
                filter.Add(String.Format("Author.UniversityId == {0}", UniversityId));
            }

            if (FacultyId is not null)
            {
                filter.Add(String.Format("Author.FacultyId == {0}", FacultyId));
            }

            if (DepartmentId is not null)
            {
                filter.Add(String.Format("Author.DepartmentId == {0}", DepartmentId));
            }

            if (DepartmentCodeId is not null)
            {
                filter.Add(String.Format("Author.Department.DepartmentCodeId == {0}", DepartmentCodeId));
            }

            if (TagId is not null)
            {
                filter.Add(String.Format("Tags.Select(x => x.TagId).Contains({0})", TagId));
            }

            if (Content is not null)
            {
                filter.Add(String.Format("Content.Contains(\"{0}\")", Content));
            }

            return String.Join(" && ", filter.ToArray());
        }
    }

    public class PostFilterValidator : AbstractValidator<PostFilter>
    {
        public PostFilterValidator()
        {
            RuleFor(x => x.AuthorId).GreaterThanOrEqualTo(1).WithName(Names.Author);

            RuleFor(x => x.Content).Length(1, 16).WithName(Names.Content);

            RuleFor(x => x.UniversityId).GreaterThanOrEqualTo(1).WithName(Names.University);
            
            RuleFor(x => x.FacultyId).GreaterThanOrEqualTo(1).WithName(Names.Faculty);

            RuleFor(x => x.DepartmentId).GreaterThanOrEqualTo(1).WithName(Names.Department);

            RuleFor(x => x.DepartmentCodeId).GreaterThanOrEqualTo(1).WithName(Names.DepartmentCode);

            RuleFor(x => x.TagId).GreaterThanOrEqualTo(1).WithName(Names.Tag);
        }
    }
}