using FMA.Application.DTOs.Tankkaarten;
using FMA.Application.Queries.Tankkaarten.ReadTankaartDetail;
using FMA.Application.Queries.Tankkaarten.ReadTankkaartList;
using FMA.Application.Queries.Tankkaarten.ReadTankkaartSelectList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FMA.Api.Read.Controllers
{
    [Route("api/read/[controller]")]
    [ApiController]
    [Authorize]
    public class TankkaartController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TankkaartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "ReadAllTankkaartenAsync")]
        public async Task<ActionResult<List<TankkaartListDTO>>> ReadAllTankkaartenAsync(CancellationToken ct)
        {
            var dto = await _mediator.Send(new ReadTankkaartListQuery(), ct);
            return Ok(dto);
        }

        [HttpGet("all/selectlist", Name = "ReadAllTankkaartenSelectListAsync")]
        public async Task<ActionResult<List<TankkaartSelectListDTO>>> ReadAllTankkaartenSelectListAsync(CancellationToken ct)
        {
            var dto = await _mediator.Send(new ReadTankkaartSelectListQuery(), ct);
            return Ok(dto);
        }

        [HttpGet("{id}", Name = "ReadTankkaartByIdAsync")]
        public async Task<ActionResult<TankkaartDTO>> ReadTankkaartByIdAsync(Guid id, CancellationToken ct)
        {
            var dto = await _mediator.Send(new ReadTankkaartDetailQuery() { Id = id }, ct);
            return Ok(dto);
        }
    }
}
