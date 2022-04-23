using System.ComponentModel.DataAnnotations;
using Core.Constants;
using Core.Entity.Abstract;
using FluentValidation;

namespace Entity.Dtos
{
    public class UserForForgetDto : IDto
    {
        public string Email { get; set; }

        public string Code { get; set; }

        public string Password { get; set; }
    }

    public class UserForForgetDtoValidator : AbstractValidator<UserForForgetDto>
    {
        public UserForForgetDtoValidator()
        {

            RuleFor(x => x.Password).Length(6, 255).NotNull().WithName(Names.Password);

            RuleFor(x => x.Email).Length(1, 255).NotNull().EmailAddress().WithName(Names.Email);

            RuleFor(x => x.Code).Length(6).NotNull().WithName(Names.Code);
        }
    }
}