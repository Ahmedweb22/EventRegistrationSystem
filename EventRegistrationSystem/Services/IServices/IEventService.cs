namespace EventRegistrationSystem.Services.IServices
{
    public interface IEventService
    {
        Task<IEnumerable<EventResponse>> GetAllEventsAsync();
        Task<EventResponse?> GetEventByIdAsync(int id);
        Task<EventResponse> CreateEventAsync(EventCreateRequest request);
    }
}
