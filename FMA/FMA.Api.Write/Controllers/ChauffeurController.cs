using FMA.Application.Commands.Chauffeurs.ActiveChauffeur;
using FMA.Application.Commands.Chauffeurs.CreateChauffeur;
using FMA.Application.Commands.Chauffeurs.UpdateChauffeur;
using FMA.Application.Commands.Gemeentes.Create;
using FMA.Startup;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace FMA.Api.Write.Controllers
{
    [Route("api/write/[controller]")]
    [ApiController]
    [Authorize]
    public class ChauffeurController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ChauffeurController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "CreateChauffeurAsync")]
        public async Task<ActionResult> CreateChauffeurAsync([FromBody] CreateChauffeurCommand command, CancellationToken ct)
        {
            var gemeenteId = await _mediator.Send(new CreateGemeenteCommand() { Postcode = command.Postcode, Stad = command.Stad, ChauffeurCommand = command }, ct);

            command.GemeenteId = gemeenteId;

            var chauffeurId = await _mediator.Send(command, ct);
            
            return Ok(chauffeurId);

        }

        [HttpPut(Name = "UpdateChauffeurAsync")]
        public async Task<ActionResult> UpdateChauffeurAsync([FromBody] UpdateChauffeurCommand command, CancellationToken ct)
        {
            var gemeenteId = await _mediator.Send(new CreateGemeenteCommand() { Postcode = command.Postcode, Stad = command.Stad }, ct);

            command.GemeenteId = gemeenteId;

            var chauffeurId = await _mediator.Send(command, ct);

            return Ok(chauffeurId);

        }

        [HttpPatch(Name = "ActiveChauffeurAsync")]
        public async Task<ActionResult> ActiveChauffeurAsync(bool active, Guid id, CancellationToken ct)
        {
            var chauffeurId = await _mediator.Send(new ActiveChauffeurCommand() { Id = id, IsActive = active }, ct);
            return Ok(chauffeurId);
        }

    }
}
