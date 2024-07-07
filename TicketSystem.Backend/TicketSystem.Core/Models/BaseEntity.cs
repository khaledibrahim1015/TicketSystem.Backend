namespace TicketSystem.Core.Models
{
    /// <summary>
    /// Represents the base entity with common properties.
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Gets or sets the entity identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the creation date of the entity.
        /// </summary>
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
    }
}
