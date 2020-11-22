using System.Threading.Tasks;
using Frank.Apps.WebApi.Models.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Frank.Apps.WebApi.Controllers
{
    [Route("api/errorresponses")]
    public class ErrorResponsesController : ControllerBase
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public ErrorResponsesController(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        [HttpGet("666")]
        public async Task<IActionResult> CriticalFailure()
        {
            ApplyErrorHeader(ResponseCode.CriticalErrorOccured);
            return Ok();
        }

        private void ApplyErrorHeader(ResponseCode responseCode)
        {
            _contextAccessor.HttpContext?.Response.Headers.Add(nameof(ResponseCode), responseCode.ToString("G"));
        }
    }
}
