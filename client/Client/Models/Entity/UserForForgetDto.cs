using Client.Models.Constants;
using Client.Models.Abstract;
using FluentValidation;

namespace Client.Models
{
    public class UserForForgetModel: IModel
    {
        public string Email { get; set; }

        public string Code { get; set; }

        public string Password { get; set; }
    }

    public class UserForForgetModelValidator : AbstractValidator<UserForForgetModel>
    {
        public UserForForgetModelValidator()
        {

            RuleFor(x => x.Password).Length(6, 255).NotNull().WithName(Names.Password);

            RuleFor(x => x.Email).Length(1, 255).NotNull().EmailAddress().WithName(Names.Email);

            RuleFor(x => x.Code).Length(6).NotNull().WithName(Names.Code);
        }
    }
}