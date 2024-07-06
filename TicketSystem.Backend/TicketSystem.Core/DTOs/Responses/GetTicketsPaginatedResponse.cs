using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Core.DTOs.Responses
{
    public  class GetTicketsPaginatedResponse
    {
        public int TotalCount { get; set; }
        public IEnumerable<GetTicketResponse> Items { get; set; }
    }
}
