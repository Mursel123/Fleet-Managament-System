using FMA.Application.DTOs.Voertuigen;
using FMA.Application.Queries.Voertuigen.GetVoertuigDetail;
using FMA.Application.Queries.Voertuigen.ReadVoertuigList;
using FMA.Application.Queries.Voertuigen.ReadVoertuigSelectList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FMA.Api.Read.Controllers
{
    [Route("api/read/[controller]")]
    [ApiController]
    public class VoertuigController : ControllerBase
    {
        private readonly IMediator _mediator;
        public VoertuigController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("all", Name = "ReadAllVoertuigenAsync")]
        public async Task<ActionResult<List<VoertuigListDTO>>> ReadAllVoertuigenAsync(CancellationToken ct)
        {
            var dto = await _mediator.Send(new ReadVoertuigListQuery(), ct);
            return Ok(dto);
        }

        [Authorize]
        [HttpGet("all/selectlist", Name = "ReadAllVoertuigenSelectListAsync")]
        public async Task<ActionResult<List<VoertuigSelectListDTO>>> ReadAllVoertuigenSelectListAsync(CancellationToken ct)
        {
            var dto = await _mediator.Send(new ReadVoertuigSelectListQuery(), ct);
            return Ok(dto);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}", Name = "ReadVoertuigenByIdAsync")]
        public async Task<ActionResult<VoertuigDTO>> ReadVoertuigenByIdAsync(Guid id, CancellationToken ct)
        {
            var dto = await _mediator.Send(new ReadVoertuigDetailQuery() { Id = id }, ct);
            return Ok(dto);
        }
    }
}
