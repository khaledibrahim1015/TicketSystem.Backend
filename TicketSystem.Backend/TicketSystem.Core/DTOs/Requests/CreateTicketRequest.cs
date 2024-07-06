namespace TicketSystem.Core.DTOs.Requests
{
    public  class CreateTicketRequest
    {
        public string PhoneNumber { get; set; }
        public string Governorate { get; set; }
        public string City { get; set; }
        public string District { get; set; }
    }
}
