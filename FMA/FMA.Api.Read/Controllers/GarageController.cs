using FMA.Application.DTOs.Garages;
using FMA.Application.Queries.Garages.ReadGarageSelectList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FMA.Api.Read.Controllers
{
    [Route("api/read/[controller]")]
    [ApiController]
    [Authorize]
    public class GarageController : ControllerBase
    {
        private readonly IMediator _mediator;
        public GarageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all/selectlist", Name = "ReadAllGaragesSelectListAsync")]
        public async Task<ActionResult<List<GarageSelectListDTO>>> ReadAllGaragesSelectListAsync(CancellationToken ct)
        {
            var dto = await _mediator.Send(new ReadGarageSelectListQuery(), ct);
            return Ok(dto);
        }
    }
}
