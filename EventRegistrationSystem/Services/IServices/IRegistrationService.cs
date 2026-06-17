namespace EventRegistrationSystem.Services.IServices
{
    public interface IRegistrationService
    {
        Task<bool> RegisterUserForEventAsync(CreateRegistrationRequest request);
        Task<IEnumerable<RegistrationResponse>> GetRegistrationsByUserIdAsync(int userId);
        Task<bool> CancelRegistrationAsync(int registrationId);
    }
}
