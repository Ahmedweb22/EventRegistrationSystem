using System.Linq.Expressions;

namespace EventRegistrationSystem.Repositories.IRepositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<int> GetCountAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        void Delete(T entity);
        Task<int> CommitAsync();

    }
}
