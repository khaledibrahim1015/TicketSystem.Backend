using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TicketSystem.API.Commands;
using TicketSystem.API.Queries;
using TicketSystem.Core.DTOs.Requests;
using TicketSystem.Core.DTOs.Responses;
using FluentValidation;
using FluentValidation.Results;
using System.Net;

namespace TicketSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<CreateTicketRequest> _createTicketRequestValidator;

        public TicketsController(IMediator mediator, IValidator<CreateTicketRequest> createTicketRequestValidator)
        {
            _mediator = mediator;
            _createTicketRequestValidator = createTicketRequestValidator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateTicketResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<CreateTicketResponse>> CreateTicket([FromBody] CreateTicketRequest createTicketRequest)
        {
            ValidationResult validationResult = await _createTicketRequestValidator.ValidateAsync(createTicketRequest);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);
            var command = new CreateTicketCommand(createTicketRequest);
            var result = await _mediator.Send(command);
            if (result != null)
                return Ok(result);
            return BadRequest("Failed to create ticket.");
        }

        [HttpGet("{id}/handle")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> HandleTicket(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid ticket ID.");
            var result = await _mediator.Send(new HandleTicketCommand(id));
            if (result)
                return Ok();
            return BadRequest("Failed to handle the ticket.");
        }

        [HttpGet("paginated")]
        [ProducesResponseType(typeof(GetTicketResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<GetTicketResponse>> GetPaginatedTickets([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            if (pageNumber <= 0 || pageSize <= 0)
                return BadRequest("Page number and page size must be greater than zero.");
            var result = await _mediator.Send(new GetAllTicketsPaginatedQuery(pageNumber, pageSize));
            return Ok(result);
        }
    }
}
