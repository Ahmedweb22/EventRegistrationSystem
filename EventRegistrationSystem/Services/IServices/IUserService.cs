namespace EventRegistrationSystem.Services.IServices
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponse>> GetAllUsersAsync();
        Task<UserResponse> GetUserByIdAsync(int id);
            Task<UserResponse> CreateUserAsync(UserCreateRequest request);
    }
}
