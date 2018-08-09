using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReadifyChallenge.Services;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using Serilog;

namespace ReadifyChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FibonacciController : ControllerBase
    {
        IAlgorithmServices algorithmServices;

        public FibonacciController(IAlgorithmServices algorithmServices) {
            this.algorithmServices = algorithmServices;
        }

        [HttpGet()]
        [SwaggerOperation(Summary = "Returns the nth number in the fibonacci sequence.",
                          Description = "Returns the nth number in the fibonacci sequence.")]
        public ActionResult GetFibonacci([Required] long n)
        {
            try
            {
                Log.Logger.Information($"BEGIN: GetFibonacci with parameter: {n} ");
                var result = algorithmServices.CalculateFibonacci(n);
                Log.Logger.Information($"END: GetFibonacci Returned: {n}");
                return Ok(result);
            } catch(Exception ex)  {
                Log.Logger.Error($"FAILED: GetFibonacci failed: {ex.Message}");
                return BadRequest();
            } 
        }

    }
}
