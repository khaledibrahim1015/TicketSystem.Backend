using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TicketSystem.API.Commands;
using TicketSystem.API.Queries;

namespace TicketSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TicketsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}/handle")]
        public async Task<IActionResult> HandleTicket(int id)
        {
            var result = await _mediator.Send(new HandleTicketCommand(id));
            if (result)
            {
                return Ok();
            }

            return BadRequest("Failed to handle the ticket");
        }

        [HttpGet("paginated")]
        public async Task<IActionResult> GetPaginatedTickets([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var result = await _mediator.Send(new GetAllTicketsPaginatedQuery(pageNumber, pageSize));
            return Ok(result);
        }
    }
}
