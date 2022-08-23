using Client.Models.Constants;
using Client.Models.Abstract;
using FluentValidation;

namespace Client.Models
{
    public class UserForConfirmModel: IModel
    {
        public string Email { get; set; }

        public string Code { get; set; }
    }

    public class UserForConfirmModelValidator : AbstractValidator<UserForConfirmModel>
    {
        public UserForConfirmModelValidator()
        {
            RuleFor(x => x.Email).Length(1, 255).NotNull().EmailAddress().WithName(Names.Email);

            RuleFor(x => x.Code).Length(6).NotNull().WithName(Names.Code);
        }
    }
}