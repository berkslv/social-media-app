using Client.Models.Constants;
using Client.Models.Abstract;
using FluentValidation;

namespace Client.Models
{
    public class DepartmentCodeForCreateModel: IModel
    {
        public string Name { get; set; }
    }

    public class DepartmentCodeForCreateModelValidator : AbstractValidator<DepartmentCodeForCreateModel>
    {
        public DepartmentCodeForCreateModelValidator()
        {
            RuleFor(x => x.Name).Length(1, 255).NotNull().WithName(Names.Name);
        }
    }
}