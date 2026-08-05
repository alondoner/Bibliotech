using Bibliotech.Domain.Entities;
using Bibliotech.Domain.Repositories;
using Bibliotech.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Bibliotech.Infrastructure.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly BibliotechDbContext _context;

        public LoanRepository(BibliotechDbContext context)
        {
            _context = context;
        }

        public Task<Loan?> GetByIdAsync(int id) =>
            _context.Loans
                .Include(l => l.Book)
                .Include(l => l.Member)
                .FirstOrDefaultAsync(l => l.Id == id);

        public Task<IEnumerable<Loan>> GetLoansByMemberAsync(int memberId) =>
            Task.FromResult(
                _context.Loans
                    .Include(l => l.Book)
                    .Include(l => l.Member)
                    .Where(l => l.MemberId == memberId)
                    .AsEnumerable()
            );

        public async Task AddAsync(Loan loan)
        {
            await _context.Loans.AddAsync(loan);
        }

        public Task SaveChangesAsync() =>
            _context.SaveChangesAsync();
    }
}
