namespace TicketSystem.Core.Models
{
    public  class Ticket : BaseEntity
    {
        public string PhoneNumber { get; set; } = string.Empty;
        public string Governorate { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public bool IsHandled { get; set; } 

    }
}
