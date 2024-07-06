using AutoMapper;
using TicketSystem.Core.DTOs.Responses;
using TicketSystem.Core.Models;

namespace TicketSystem.API.MappingProfiles
{
    public class DomainToResponse :Profile
    {
        public DomainToResponse()
        {
            CreateMap<Ticket , CreateTicketResponse>(); 
        }
    }
}
