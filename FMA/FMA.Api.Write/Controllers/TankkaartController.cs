using FMA.Application.Commands.Tankkaarten.BlockTankkaart;
using FMA.Application.Commands.Tankkaarten.CreateTankkaart;
using FMA.Application.Commands.Tankkaarten.DeleteTankkaart;
using FMA.Application.Commands.Tankkaarten.UnblockTankkaart;
using FMA.Application.Commands.Tankkaarten.UpdateTankkaart;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FMA.Api.Write.Controllers
{
    [Route("api/write/[controller]")]
    [ApiController]
    [Authorize]
    public class TankkaartController : ControllerBase
    {
        
        private readonly IMediator _mediator;
        public TankkaartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "CreateTankkaartAsync")]
        public async Task<ActionResult> CreateTankkaartAsync([FromBody] CreateTankkaartCommand createTankkaartCommand, CancellationToken ct)
        {
            var tankkaartId = await _mediator.Send(createTankkaartCommand, ct);
            return Ok(tankkaartId);
        }

        [HttpPut(Name = "UpdateTankkaartAsync")]
        public async Task<ActionResult> UpdateTankkaartAsync([FromBody] UpdateTankkaartCommand updateTankkaartCommand, CancellationToken ct)
        {
            var tankkaartId = await _mediator.Send(updateTankkaartCommand, ct);
            return Ok(tankkaartId);
        }
        [HttpPut("block/{id}", Name = "BlockTankkaartAsync")]
        public async Task<ActionResult> BlockTankkaartAsync(Guid id, CancellationToken ct)
        {
            var tankkaartId = await _mediator.Send(new BlockTankkaartCommand() { Id = id }, ct);
            return Ok(tankkaartId);
        }

        [HttpPut("unblock/{id}", Name = "UnblockTankkaartAsync")]
        public async Task<ActionResult> UnblockTankkaartAsync(Guid id, CancellationToken ct)
        {
            var tankkaartId = await _mediator.Send(new UnblockTankkaartCommand() { Id = id }, ct);
            return Ok(tankkaartId);
        }

        [HttpDelete("{id}", Name = "DeleteTankkaartAsync")]
        public async Task<ActionResult> DeleteTankkaartAsync(Guid id, CancellationToken ct)
        {
            var tankkaartId = await _mediator.Send(new DeleteTankkaartCommand() { Id = id }, ct);
            return Ok(tankkaartId);
        }
    }
}
