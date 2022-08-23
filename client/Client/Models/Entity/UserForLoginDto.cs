using Client.Models.Constants;
using Client.Models.Abstract;
using FluentValidation;

namespace Client.Models
{
    public class UserForLoginModel: IModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UserForLoginModelValidator : AbstractValidator<UserForLoginModel>
    {
        public UserForLoginModelValidator()
        {

            RuleFor(x => x.Password).Length(6, 255).NotNull().WithName(Names.Password);

            RuleFor(x => x.Email).Length(1, 255).NotNull().EmailAddress().WithName(Names.Email);
            
        }
    }
}
