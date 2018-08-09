using System;
using Microsoft.AspNetCore.Mvc;
using ReadifyChallenge.Services;
using Swashbuckle.AspNetCore.Annotations;
using Serilog;

namespace ReadifyChallenge.Controllers
{
    [Route("api/[controller]")]
    public class ReverseWordsController : ControllerBase
    {
        IAlgorithmServices algorithmServices;

        public ReverseWordsController(IAlgorithmServices algorithmServices)
        {
            this.algorithmServices = algorithmServices;
        }

        [SwaggerOperation(Summary = "Reverses the letters of each word in a sentence.",
                          Description = "Reverses the letters of each word in a sentence.")]
        [HttpGet()]
        public ActionResult GetReversed(string sentence)
        {
            try {
                Log.Logger.Information($"BEGIN: GetReversed with parameter: {sentence} ");
                var reversedSentence = algorithmServices.GetReversedSentence(sentence);
                Log.Logger.Information($"END: GetReversed with parameter: {reversedSentence} ");
                return Ok(reversedSentence);    
            } catch (Exception ex) {
                Log.Logger.Error($"FAILED: GetReversed failed: {ex.Message} ");
                throw ex;
            }
        }
    }
}
