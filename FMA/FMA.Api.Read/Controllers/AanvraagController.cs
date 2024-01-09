using FMA.Application.DTOs.Aanvragen;
using FMA.Application.Queries.Aanvragen.ReadAanvraagDetail;
using FMA.Application.Queries.Aanvragen.ReadAanvraagList;
using FMA.Application.Queries.Aanvragen.ReadAanvraagNotification;
using FMA.Application.Queries.Aanvragen.ReadAanvragenCount;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FMA.Api.Read.Controllers
{
    [Route("api/read/[controller]")]
    [ApiController]
    public class AanvraagController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AanvraagController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [Authorize(Roles = "Admin")]
        [HttpGet("in_behandeling={inBehandeling}/all", Name = "ReadAanvragenAsync")]
        public async Task<ActionResult<List<AanvraagDTO>>> ReadAanvragenAsync(bool inBehandeling, CancellationToken ct)
        {
            var dto = await _mediator.Send(new ReadAanvraagListQuery() { InBehandeling = inBehandeling }, ct);
            return Ok(dto);
        }

        [Authorize]
        [HttpGet("email/all", Name = "ReadAanvragenByEmailAsync")]
        public async Task<ActionResult<List<AanvraagDTO>>> ReadAanvragenByEmailAsync(CancellationToken ct)
        {
            var chauffeurEmail = User.Claims.FirstOrDefault(x => x.Type == "email")?.Value;

            var dto = await _mediator.Send(new ReadAanvraagListQuery() { Email = chauffeurEmail }, ct);
            return Ok(dto);
        }

        [Authorize]
        [HttpGet("notification/all", Name = "ReadAanvragenNotificationAsync")]
        public async Task<ActionResult<List<AanvraagNotificationListDTO>>> ReadAanvragenNotificationAsync(CancellationToken ct)
        {
            var chauffeurEmail = User.Claims.FirstOrDefault(x => x.Type == "email")?.Value;

            var dto = await _mediator.Send(new ReadAanvraagNotificationQuery() { Email = chauffeurEmail }, ct);
            return Ok(dto);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("in_behandeling/count", Name = "ReadAanvragenInBehandelingCountAsync")]
        public async Task<ActionResult<int>> ReadAanvragenInBehandelingCountAsync(CancellationToken ct)
        {
            var count = await _mediator.Send(new ReadAanvragenCountQuery(), ct);
            return Ok(count);
        }

        [Authorize]
        [HttpGet("{id}", Name = "ReadAanvraagByIdAsync")]
        public async Task<ActionResult<AanvraagDTO>> ReadAanvraagByIdAsync(Guid id, CancellationToken ct)
        {
            var dto = await _mediator.Send(new ReadAanvraagDetailQuery() { Id = id }, ct);
            return Ok(dto);
        }
    }
}
