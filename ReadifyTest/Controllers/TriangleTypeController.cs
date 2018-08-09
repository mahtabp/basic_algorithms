using System;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using ReadifyCallenge.Services;
using System.ComponentModel.DataAnnotations;
using Serilog;

namespace ReadifyCallenge.Controllers
{
    [Route("api/[controller]")]
    public class TriangleTypeController : ControllerBase
    {
        ITriangleService triangleService;

        public TriangleTypeController(ITriangleService triangleService)
        {
            this.triangleService = triangleService;
        }

        [HttpGet("")]
        [SwaggerOperation(Summary = "Returns the type of triange given the lengths of its sides",
                          Description = "Returns the type of triange given the lengths of its sides")]
        public ActionResult Get([Required]int a, [Required]int b, [Required]int c)
        {
            try {
                Log.Logger.Information($"BEGIN: Get TriangleType with params: a={a}, b={b}, c = {c}");
                var result = triangleService.GetTriangleType(a, b, c).ToString();
                Log.Logger.Information($"END: Get TriangleType: result={result}");
                return Ok(result);    
            } catch (Exception ex) {
                Log.Logger.Error($"FAILED: Get TriangleType failed {ex.Message}");
                throw ex;
            }

        }

    }
}
