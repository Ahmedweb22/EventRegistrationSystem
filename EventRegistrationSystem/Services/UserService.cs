using Microsoft.AspNetCore.Http.HttpResults;

namespace EventRegistrationSystem.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;
        public UserService(IRepository<User> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<UserResponse>> GetAllUsersAsync()
        {
            var users = await _repository.GetAllAsync();
            return users.Select(u => new UserResponse
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email
            });
        }
        public async Task<UserResponse> GetUserByIdAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null)
            {
                return null;
            }
            return new UserResponse
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }
        public async Task<UserResponse> CreateUserAsync(UserCreateRequest request)
        {
            var newUser = new User
            {
                Name = request.Name,
                Email = request.Email
            };
            await _repository.AddAsync(newUser);
            await _repository.CommitAsync();
            return new UserResponse
            {
                Id = newUser.Id,
                Name = newUser.Name,
                Email = newUser.Email
            };
        }
}
}
