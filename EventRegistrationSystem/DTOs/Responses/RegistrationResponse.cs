namespace EventRegistrationSystem.DTOs.Responses
{
    public class RegistrationResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int EventId { get; set; }
        public string EventTitle { get; set; }
        public DateTime RegistratedAt { get; set; }
    }
}
