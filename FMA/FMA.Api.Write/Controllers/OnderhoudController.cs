using FMA.Application.Commands.Aanvragen.Update;
using FMA.Application.Commands.Facturen.Create;
using FMA.Application.Commands.Onderhouden.Create;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FMA.Api.Write.Controllers
{
    [Route("api/write/[controller]")]
    [ApiController]
    [Authorize]
    public class OnderhoudController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OnderhoudController(IMediator mediator)
        {
            _mediator = mediator;
        }

        
        
        [HttpPost(Name = "CreateOnderhoudAsync")]
        public async Task<ActionResult> CreateOnderhoudAsync([FromBody] CreateOnderhoudCommand command, CancellationToken ct)
        {
            var onderhoudId = await _mediator.Send(command, ct);
            var updateAanvraagCommand = new UpdateAanvraagCommand(){ Id = command.AanvraagId, OnderhoudId = onderhoudId };
            var aanvraagId = await _mediator.Send(updateAanvraagCommand, ct);
            return Ok(aanvraagId);
        }
    }
}
