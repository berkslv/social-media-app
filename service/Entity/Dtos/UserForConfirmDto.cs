using System.ComponentModel.DataAnnotations;
using Core.Constants;
using Core.Entity.Abstract;
using FluentValidation;

namespace Entity.Dtos
{
    public class UserForConfirmDto : IDto
    {
        public string Email { get; set; }

        public string Code { get; set; }
    }

    public class UserForConfirmDtoValidator : AbstractValidator<UserForConfirmDto>
    {
        public UserForConfirmDtoValidator()
        {
            RuleFor(x => x.Email).Length(1, 255).NotNull().EmailAddress().WithName(Names.Email);

            RuleFor(x => x.Code).Length(6).NotNull().WithName(Names.Code);
        }
    }
}