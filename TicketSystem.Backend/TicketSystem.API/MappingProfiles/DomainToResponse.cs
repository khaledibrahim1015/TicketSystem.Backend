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
                     Color = TicketService.GetTicketColor(ticket.CreationDate),  
                 })
             );

            CreateMap<IEnumerable<Ticket>, GetTicketsPaginatedResponse>()
             .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src))
                 .ForMember(dest => dest.TotalCount, opt => opt.Ignore()); // Ignore TotalCount mapping here

            CreateMap<Ticket, GetTicketResponse>()
                .ForMember(dest => dest.Color, opt => opt.MapFrom(src => TicketService.GetTicketColor(src.CreationDate)));



        }
    }
}
