namespace EventRegistrationSystem.Services
{
    public class EventService : IEventService
    {
        private readonly IRepository<Event> _eventRepository;
        public EventService(IRepository<Event> eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<IEnumerable<EventResponse>> GetAllEventsAsync()
        {
            var events = await _eventRepository.GetAllAsync();
            return events.Select(e => new EventResponse
            {
                Id = e.Id,
                Title = e.Title,
                Description = e.Description,
                Date = e.Date,
                Location = e.Location,
                Capacity = e.Capacity
            });
        }
        public async Task<EventResponse?> GetEventByIdAsync(int id)
        {
            var e = await _eventRepository.GetByIdAsync(id);
            if (e == null) return null;
            return new EventResponse
            {
                Id = e.Id,
                Title = e.Title,
                Description = e.Description,
                Date = e.Date,
                Location = e.Location,
                Capacity = e.Capacity
            };
        }
        public async Task<EventResponse> CreateEventAsync(EventCreateRequest request)
        {
            var newEvent = new Event
            {
                Title = request.Title,
                Description = request.Description,
                Date = request.Date,
                Location = request.Location,
                Capacity = request.Capacity
            };
            await _eventRepository.AddAsync(newEvent);
            await _eventRepository.CommitAsync();
            return new EventResponse
            {
                Id = newEvent.Id,
                Title = newEvent.Title,
                Description = newEvent.Description,
                Date = newEvent.Date,
                Location = newEvent.Location,
                Capacity = newEvent.Capacity
            };
        }
    }
}
