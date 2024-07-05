using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Core.Models
{
    public  class Ticket
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public string PhoneNumber { get; set; } = string.Empty;

        public string Governorate { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;

        public bool IsHandled { get; set; } 


    }
}
