namespace EventRegistrationSystem.Repositories
{
    public class RegistrationRepository : Repository<Registration>, IRegistrationRepository
    {
        public RegistrationRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Registration>> GetByUserIdAsync(int userId)
        {
            return await _context.Registrations
                       .Include(r => r.Event)
                       .Include(r => r.User)
                .Where(r => r.UserId == userId)
                .ToListAsync();
        }
    
    
    }
}
