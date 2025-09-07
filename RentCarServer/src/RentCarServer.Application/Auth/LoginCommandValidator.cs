using FluentValidation;

namespace RentCarServer.Application.Auth;

public sealed class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(i => i.EmailOrUserName).NotEmpty().WithMessage("Geçerli bir mail yada kullanıcı adı giriniz.");
        RuleFor(i => i.Password).NotEmpty().WithMessage("Geçerli bir şifre giriniz.");
    }
}