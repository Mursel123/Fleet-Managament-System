using FMA.Application.DTOs.Verzekeringsmaatschappijen;
using FMA.Application.Queries.Verzekeringsmaatschappijen;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FMA.Api.Read.Controllers
{
    [Route("api/read/[controller]")]
    [Authorize]
    [ApiController]
    public class VerzekeringsmaatschappijController : ControllerBase
    {
        private readonly IMediator _mediator;
        public VerzekeringsmaatschappijController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all/selectlist", Name = "ReadAllVerzekeringsmaatschappijenSelectListAsync")]
        public async Task<ActionResult<List<VerzekeringsmaatschappijSelectListDTO>>> ReadAllVerzekeringsmaatschappijenSelectListAsync(CancellationToken ct)
        {
            var dto = await _mediator.Send(new ReadVerzekeringsmaatschappijSelectListQuery(), ct);
            return Ok(dto);
        }
    }
}
