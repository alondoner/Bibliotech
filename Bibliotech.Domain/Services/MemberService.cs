using Bibliotech.Domain.Entities;
using Bibliotech.Domain.Repositories;

namespace Bibliotech.Domain.Services
{
    public class MemberService
    {
        private readonly IMemberRepository _members;

        public MemberService(IMemberRepository members)
        {
            _members = members;
        }

        public Task<Member?> GetByIdAsync(int id) => _members.GetByIdAsync(id)
                ?? throw new Exception("Adhérent introuvable");

        public async Task AddAsync(Member member)
        {
            await _members.AddAsync(member);
            await _members.SaveChangesAsync();
        }
    }
}
