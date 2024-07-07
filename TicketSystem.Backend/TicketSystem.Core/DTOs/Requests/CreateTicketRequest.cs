namespace TicketSystem.Core.DTOs.Requests
{
    /// <summary>
    /// Represents a request to create a ticket.
    /// </summary>
    public class CreateTicketRequest
    {
        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the governorate.
        /// </summary>
        public string Governorate { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the district.
        /// </summary>
        public string District { get; set; }
    }
}
