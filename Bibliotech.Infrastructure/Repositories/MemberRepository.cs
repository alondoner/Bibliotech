using Bibliotech.Domain.Entities;

namespace Bibliotech.Domain.Repositories
{
    public interface IMemberRepository
    {
        Task<Member?> GetByIdAsync(int id);
        Task<IEnumerable<Member>> GetAllAsync();
        Task AddAsync(Member member);
        Task SaveChangesAsync();
    }
}
