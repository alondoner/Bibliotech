using Bibliotech.Domain.Entities;
using Bibliotech.Domain.Repositories;

public class FakeLoanRepository : ILoanRepository
{
    public List<Loan> Loans = new();

    public Task AddAsync(Loan loan)
    {
        Loans.Add(loan);
        return Task.CompletedTask;
    }

    public Task<Loan?> GetByIdAsync(int id) =>
        Task.FromResult(Loans.FirstOrDefault(l => l.Id == id));

    public Task<IEnumerable<Loan>> GetLoansByMemberAsync(int memberId) =>
        Task.FromResult(Loans.Where(l => l.MemberId == memberId).AsEnumerable());

    public Task SaveChangesAsync() => Task.CompletedTask;
}
