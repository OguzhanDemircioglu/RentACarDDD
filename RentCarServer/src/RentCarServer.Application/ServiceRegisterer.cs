using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using RentCarServer.Application.Behaviors;
using TS.MediatR;

namespace RentCarServer.Application;

public static class ServiceRegisterer
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(crf =>
        {
            crf.RegisterServicesFromAssembly(typeof(ServiceRegisterer).Assembly);
            crf.AddOpenBehavior(typeof(ValidationBehavior<,>));
            crf.AddOpenBehavior(typeof(PermissionBehavior<,>));
        });
        services.AddValidatorsFromAssembly(typeof(ServiceRegisterer).Assembly);
        return services;
    }
}