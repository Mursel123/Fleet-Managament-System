using FMA.Application.DTOs.Chauffeurs;
using FMA.Application.Queries.Chauffeurs.ReadChauffeurDetail;
using FMA.Application.Queries.Chauffeurs.ReadChauffeurList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FMA.Api.Read.Controllers
{
    [Route("api/read/[controller]")]
    [ApiController]
    public class ChauffeurController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ChauffeurController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("all", Name = "ReadAllChauffeursAsync")]
        public async Task<ActionResult<List<ChauffeurListDTO>>> ReadAllChauffeursAsync(CancellationToken ct)
        {
            var dto = await _mediator.Send(new ReadChauffeurListQuery(), ct);
            return Ok(dto);
        }

        [Authorize]
        [HttpGet("{id}", Name = "ReadChauffeurByIdAsync")]
        public async Task<ActionResult<ChauffeurDTO>> ReadChauffeurByIdAsync(Guid id, CancellationToken ct)
        {
            var dto = await _mediator.Send(new ReadChauffeurDetailQuery() { Id = id }, ct);
            return Ok(dto);
        }

        [Authorize]
        [HttpGet("email", Name = "ReadChauffeurByEmailAsync")]
        public async Task<ActionResult<ChauffeurDTO>> ReadChauffeurByEmailAsync(CancellationToken ct)
        {
            var chauffeurEmail = User.Claims.FirstOrDefault(x => x.Type == "email")?.Value;
            
            var dto = await _mediator.Send(new ReadChauffeurDetailQuery() { Email = chauffeurEmail }, ct);
            return Ok(dto);
        }
    }
}
