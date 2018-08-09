using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ReadifyChallenge.Models;
using Swashbuckle.AspNetCore.Annotations;
using Serilog;

namespace ReadifyChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        IConfiguration configuration;
        public TokenController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet()]
        [SwaggerOperation(Summary = "Your Token.",
                          Description = "Your Token.")]
        public ActionResult Get()
        {
            Log.Logger.Information($"BEGIN: Get Token ");
            var appSettingsConfig = configuration.GetSection("AppSettings");
            var appSettings = appSettingsConfig.Get<AppSettings>();
            var myToken = appSettings.MahtabToken;
            Log.Logger.Information($"END: Get Token {myToken}");
            return Ok(myToken);
        }
    }
}
