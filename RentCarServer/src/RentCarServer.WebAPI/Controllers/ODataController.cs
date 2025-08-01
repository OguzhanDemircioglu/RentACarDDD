using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace RentCarServer.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[EnableQuery]
public class ODataController : ControllerBase
{
    public static IEdmModel GetEdmModel()
    {
        ODataConventionModelBuilder builder = new();
        builder.EnableLowerCamelCase();
        return builder.GetEdmModel();
    }
    [HttpGet("ping")]
    public IActionResult Ping() => Ok("pong");

}