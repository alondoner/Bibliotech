using Bibliotech.Domain.Entities;
using Bibliotech.Domain.Repositories;
using Bibliotech.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Bibliotech.Infrastructure.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly BibliotechDbContext _context;

        public MemberRepository(BibliotechDbContext context)
        {
            _context = context;
        }

        public Task<Member?> GetByIdAsync(int id) =>
            //_context.Members.FirstOrDefaultAsync(m => m.Id == id);
            _context.Members.FindAsync(id).AsTask();

        public Task<IEnumerable<Member>> GetAllAsync() =>
            Task.FromResult(_context.Members.AsEnumerable());

        public async Task AddAsync(Member member)
        {
            await _context.Members.AddAsync(member);
        }

        public Task SaveChangesAsync() =>
            _context.SaveChangesAsync();
    }
}
