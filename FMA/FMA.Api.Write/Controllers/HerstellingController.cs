using FMA.Application.Commands.Aanvragen.Update;
using FMA.Application.Commands.Facturen.Create;
using FMA.Application.Commands.Herstellingen.Create;
using FMA.Application.Commands.Onderhouden.Create;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FMA.Api.Write.Controllers
{
    [Route("api/write/[controller]")]
    [Authorize]
    [ApiController]
    public class HerstellingController : ControllerBase
    {
        private readonly IMediator _mediator;
        public HerstellingController(IMediator mediator)
        {
            _mediator = mediator;
        }



        [HttpPost(Name = "CreateHerstellingAsync")]
        public async Task<ActionResult> CreateHerstellingAsync([FromBody] CreateHerstellingCommand command, CancellationToken ct)
        {
            var herstellingId = await _mediator.Send(command, ct);
            var updateAanvraagCommand = new UpdateAanvraagCommand() { Id = command.AanvraagId, HerstellingId = herstellingId };
            var aanvraagId = await _mediator.Send(updateAanvraagCommand, ct);
            return Ok(aanvraagId);
        }
    }
}
