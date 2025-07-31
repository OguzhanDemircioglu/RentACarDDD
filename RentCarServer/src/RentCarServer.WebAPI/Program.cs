using System.Threading.RateLimiting;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.RateLimiting;
using RentCarServer.Application;
using RentCarServer.Infrastructure;
using RentCarServer.WebAPI.Controllers;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddRateLimiter(cfr =>
{
    cfr.AddFixedWindowLimiter("fixed", opt =>
    {
        opt.PermitLimit = 100;
        opt.QueueLimit = 100;
        opt.Window = TimeSpan.FromSeconds(1);
        opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
    });
});
builder.Services.AddControllers()
    .AddOData(opt =>
    {
        opt.Select()
            .Filter()
            .Expand()
            .OrderBy()
            .SetMaxTop(null)
            .AddRouteComponents("odata", ODataController.GetEdmModel());
    });

builder.Services.AddCors();
builder.Services.AddOpenApi();

var app = builder.Build();
app.MapOpenApi();
app.MapScalarApiReference();
app.UseHttpsRedirection();
app.UseCors(x => x
    .AllowAnyHeader()
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .SetPreflightMaxAge(TimeSpan.FromMinutes(10)));
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers().RequireRateLimiting("fixed");
app.Run();