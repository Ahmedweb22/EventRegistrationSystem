namespace EventRegistrationSystem.Models
{
    public class Registration
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public User? User { get; set; } 
        public Event? Event { get; set; }
    }
}
