using AutoMapper;
using TicketSystem.Core.DTOs.Requests;
using TicketSystem.Core.Models;

namespace TicketSystem.API.MappingProfiles
{
    public class RequestToDomain :Profile
    {
        public RequestToDomain()
        {
            CreateMap<CreateTicketRequest, Ticket>();
        }
    }
}
