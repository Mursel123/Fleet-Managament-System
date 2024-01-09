using FMA.Application.DTOs.GemeldeSchades;
using FMA.Application.Queries.GemeldeSchades.ReadGemeldeSchadeSelectList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FMA.Api.Read.Controllers
{
    [Route("api/read/[controller]")]
    [Authorize]
    [ApiController]
    public class GemeldeSchadeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public GemeldeSchadeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all/selectlist", Name = "ReadAllGemeldeSchadesSelectListAsync")]
        public async Task<ActionResult<List<GemeldeSchadeSelectListDTO>>> ReadAllGemeldeSchadesSelectListAsync(CancellationToken ct)
        {
            var dto = await _mediator.Send(new ReadGemeldeSchadeSelectListQuery(), ct);
            return Ok(dto);
        }
    }
}
