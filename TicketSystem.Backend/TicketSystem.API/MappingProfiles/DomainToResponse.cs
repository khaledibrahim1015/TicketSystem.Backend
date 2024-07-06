using AutoMapper;
using TicketSystem.Core.DTOs.Responses;
using TicketSystem.Core.Models;
using TicketSystem.DAl.Services;

namespace TicketSystem.API.MappingProfiles
{
    public class DomainToResponse :Profile
    {
        public DomainToResponse()
        {
            CreateMap<Ticket , CreateTicketResponse>();
            CreateMap<IEnumerable<Ticket>, IEnumerable<GetTicketResponse>>()
             .ConvertUsing(tickets =>
                 tickets.Select(ticket => new GetTicketResponse
                 {
                     Id = ticket.Id,
                     CreationDate = ticket.CreationDate,
                     PhoneNumber = ticket.PhoneNumber,
                     Governorate = ticket.Governorate,
                     City = ticket.City,
                     District = ticket.District,
                     IsHandled = ticket.IsHandled,
                     Color = TicketService.GetTicketColor(ticket.CreationDate) 
                 })
             );
        }
    }
}
