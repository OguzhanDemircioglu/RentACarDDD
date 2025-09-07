using RentCarServer.Application.Services;
using RentCarServer.Domain.Users;
using TS.MediatR;
using TS.Result;

namespace RentCarServer.Application.Auth;

public sealed class LoginCommandHandler(IUserRepository userRepository, IJwtProvider jwtProvider)
    : IRequestHandler<LoginCommand, Result<string>>
{
    public async Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.FirstOrDefaultAsync(p =>
            p.UserName.Value == request.EmailOrUserName || p.Email.Value == request.EmailOrUserName);

        if (user is null)
        {
            return Result<string>.Failure("Kullanıcı adı veya şifre yanlış");
        }

        var checkPassword = user.VerifyPasswordHash(request.Password);

        if (!checkPassword)
        {
            return Result<string>.Failure("Kullanıcı adı veya şifre yanlış");
        }

        var token = jwtProvider.CreateToken(user);

        return token;
    }
}