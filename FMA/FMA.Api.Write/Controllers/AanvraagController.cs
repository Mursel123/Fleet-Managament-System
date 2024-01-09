using FMA.Application.Commands.Aanvragen.Create;
using FMA.Application.Commands.Aanvragen.UpdateStatus;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FMA.Api.Write.Controllers
{
    [Route("api/write/[controller]")]
    [ApiController]
    public class AanvraagController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AanvraagController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost(Name = "CreateAanvraagAsync")]
        public async Task<ActionResult> CreateAanvraagAsync([FromBody] CreateAanvraagCommand command, CancellationToken ct)
        {
            command.Email = User.Claims.FirstOrDefault(x => x.Type == "email")?.Value;
            var aanvraagId = await _mediator.Send(command, ct);
            return Ok(aanvraagId);

        }

        [Authorize]
        [HttpPatch("status", Name = "UpdateAanvraagStatusAsync")]
        public async Task<ActionResult> UpdateAanvraagStatusAsync([FromBody] UpdateAanvraagStatusCommand command, CancellationToken ct)
        {
            var aanvraagId = await _mediator.Send(command, ct);
            return Ok(aanvraagId);

        }
    }
}
