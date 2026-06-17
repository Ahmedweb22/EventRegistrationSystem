namespace EventRegistrationSystem.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IRegistrationRepository _registrationRepository;
        private readonly IRepository<Event> _eventRepository;
        public RegistrationService(IRegistrationRepository registrationRepository, IRepository<Event> eventRepository)
        {
            _registrationRepository = registrationRepository;
            _eventRepository = eventRepository;
        }
        public async Task<bool> RegisterUserForEventAsync(CreateRegistrationRequest request)
        {
            var e = await _eventRepository.GetByIdAsync(request.EventId);
            if (e == null) return false;
          var currentRegistrations = await _registrationRepository.GetAllAsync();
            //var count = currentRegistrations.Count(r => r.EventId == request.EventId);
            var count = await _registrationRepository.GetCountAsync(r => r.EventId == request.EventId);
            if (count >= e.Capacity) return false;
            var registration = new Registration
            {
                UserId = request.UserId,
                EventId = request.EventId,
                RegistrationDate = DateTime.UtcNow
            };
            await _registrationRepository.AddAsync(registration);
            return await _registrationRepository.CommitAsync() > 0;

        }
        public async Task<IEnumerable<RegistrationResponse>> GetRegistrationsByUserIdAsync(int userId)
        {
            var registrations = await _registrationRepository.GetByUserIdAsync(userId);
            return registrations.Select(r => new RegistrationResponse
            {
                Id = r.Id,
                UserId = r.UserId,
                EventId = r.EventId,
                RegistratedAt = r.RegistrationDate
            });
        }
        public async Task<bool> CancelRegistrationAsync(int registrationId)
        {
            var registration = await _registrationRepository.GetByIdAsync(registrationId);
            if (registration == null) return false;
            _registrationRepository.Delete(registration);
            return await _registrationRepository.CommitAsync() > 0;
        }
    }
}
