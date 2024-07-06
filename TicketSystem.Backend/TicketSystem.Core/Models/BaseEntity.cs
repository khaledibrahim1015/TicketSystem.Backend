namespace TicketSystem.Core.Models
{
    public  class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
    }
}
