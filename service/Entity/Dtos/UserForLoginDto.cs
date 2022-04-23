using Core.Constants;
using Core.Entity.Abstract;
using FluentValidation;

namespace Entity.Dtos
{
    public class UserForLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UserForLoginDtoValidator : AbstractValidator<UserForLoginDto>
    {
        public UserForLoginDtoValidator()
        {

            RuleFor(x => x.Password).Length(6, 255).NotNull().WithName(Names.Password);

            RuleFor(x => x.Email).Length(1, 255).NotNull().EmailAddress().WithName(Names.Email);
            
        }
    }
}
