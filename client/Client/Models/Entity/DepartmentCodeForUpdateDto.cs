using Client.Models.Constants;
using Client.Models.Abstract;
using FluentValidation;

namespace Client.Models
{
    public class DepartmentCodeForUpdateModel: IModel
    {
        public string Name { get; set; }
    }


    public class DepartmentCodeForUpdateModelValidator : AbstractValidator<DepartmentCodeForUpdateModel>
    {
        public DepartmentCodeForUpdateModelValidator()
        {
            RuleFor(x => x.Name).Length(1, 255).NotNull().WithName(Names.Name);
        }
    }
}