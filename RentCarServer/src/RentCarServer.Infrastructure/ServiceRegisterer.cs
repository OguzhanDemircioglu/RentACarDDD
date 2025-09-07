using GenericRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentCarServer.Infrastructure.Context;
using RentCarServer.Infrastructure.Options;
using Scrutor;

namespace RentCarServer.Infrastructure;

public static class ServiceRegisterer
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtOptions>(configuration.GetSection("Jwt"));
        services.AddHttpContextAccessor();
        services.AddDbContext<ApplicationDbContext>(opt =>
        {
            var connectionString = configuration.GetConnectionString("SqlServer")!;
            opt.UseSqlServer(connectionString);
        });

        services.AddScoped<IUnitOfWork>(sev=>sev.GetRequiredService<ApplicationDbContext>());

        services.Scan(action => action.FromAssemblies(typeof(ServiceRegisterer).Assembly)
            .AddClasses(publicOnly: false)
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        return services;
    }
}