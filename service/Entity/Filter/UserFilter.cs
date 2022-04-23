using System.Linq.Expressions;
using Core.Constants;
using Core.Entity.Concrete;
using Core.Extensions;
using Core.Utilities.Query;
using Entity.Concrete;
using Entity.Enum;
using FluentValidation;

namespace Entity.Filter
{
    public class UserFilter : FilterParameters
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public int? UniversityId { get; set; }

        public int? FacultyId { get; set; }

        public int? DepartmentId { get; set; }
        
        public string Role { get; set; }

        public void CreateQuery()
        {
            base.OrderBy = base.CreateSortWithType(typeof(User));
            base.Filter = CreateFilter();
        }

        protected string CreateFilter()
        {
            var filter = new List<String>();

            if (UniversityId is not null)
            {
                filter.Add(String.Format("UniversityId == {0}", UniversityId));
            }

            if (FacultyId is not null)
            {
                filter.Add(String.Format("FacultyId == {0}", FacultyId));
            }

            if (DepartmentId is not null)
            {
                filter.Add(String.Format("DepartmentId == {0}", DepartmentId));
            }

            if (Name is not null)
            {
                filter.Add(String.Format("Name.Contains(\"{0}\")", Name));
            }

            if (Email is not null)
            {
                filter.Add(String.Format("Email.Contains(\"{0}\")", Email));
            }

            if (Username is not null)
            {
                filter.Add(String.Format("Username.Contains(\"{0}\")", Username));
            }

            if (Role is not null)
            {
                filter.Add(String.Format("Role.Contains(\"{0}\")", Role));
            }

            return String.Join(" && ", filter.ToArray());;
        }
    }

    public class UserFilterValidator : AbstractValidator<UserFilter>
    {
        public UserFilterValidator()
        {
            RuleFor(x => x.Name).Length(1, 255).WithName(Names.Name);


            RuleFor(x => x.Email).Length(1, 255).EmailAddress().WithName(Names.Email);
            
            RuleFor(x => x.Username).Length(1, 255).WithName(Names.Username);

            When(x => x.Role != Core.Entity.Concrete.Role.Student, () => {
                RuleFor(x => x.UniversityId).Null().WithName(Names.University);

                RuleFor(x => x.FacultyId).Null().WithName(Names.Faculty);

                RuleFor(x => x.DepartmentId).Null().WithName(Names.Department);
            });
            
        }
    }
}