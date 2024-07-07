namespace TicketSystem.Core.Models
{
    /// <summary>
    /// Represents a ticket entity.
    /// </summary>
    public class Ticket : BaseEntity
    {
        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        public string PhoneNumber { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the governorate.
        /// </summary>
        public string Governorate { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        public string City { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the district.
        /// </summary>
        public string District { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether the ticket is handled.
        /// </summary>
        public bool IsHandled { get; set; }
    }
}
