using FMA.Application;
using FMA.Domain.Config;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FMA.Api.Read.Controllers
{
    [Route("api/read/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private readonly SignalR _optionsSignalR;
        public ConfigController(IOptions<SignalR> optionsSignalR)
        {
            _optionsSignalR = optionsSignalR.Value;
        }
        [HttpGet("signalr",Name = "ReadSignalRConfig")]
        public ActionResult<SignalR> ReadSignalRConfig()
        {
            return Ok(_optionsSignalR);
        }

    }
}
