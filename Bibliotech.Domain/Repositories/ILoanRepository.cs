using Bibliotech.Domain.Entities;

namespace Bibliotech.Domain.Repositories
{
    public interface ILoanRepository
    {
        Task<Loan?> GetByIdAsync(int id);
        Task<IEnumerable<Loan>> GetLoansByMemberAsync(int memberId);
        Task AddAsync(Loan loan);
        Task SaveChangesAsync();
    }
}
