namespace EventRegistrationSystem.Repositories.IRepositories
{
    public interface IRegistrationRepository : IRepository<Registration>
    {
        Task<IEnumerable<Registration>> GetByUserIdAsync(int userId);
    }
}
