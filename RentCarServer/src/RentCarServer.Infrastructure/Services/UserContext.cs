using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using RentCarServer.Application.Services;

namespace RentCarServer.Infrastructure.Services;

internal sealed class UserContext(HttpContextAccessor httpContextAccessor) : IUserContext
{
    public Guid GetUserId()
    {
        var httpContext = httpContextAccessor.HttpContext;
        var claims = httpContext?.User.Claims;
        var userId = claims?.FirstOrDefault(i => i.Type == ClaimTypes.NameIdentifier)?.Value;
        if (userId is null)
        {
            throw new ArgumentNullException("Kullanıcı Kaydı Bulunamadı");
        }

        try
        {
            Guid id = Guid.Parse(userId);
            return id;
        }
        catch (Exception e)
        {
            throw new ArgumentException("Kullanıcı ID uygun Guid Formatında Değil", e);
        }
    }
}