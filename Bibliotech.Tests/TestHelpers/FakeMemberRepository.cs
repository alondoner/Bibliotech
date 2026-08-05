using Bibliotech.Domain.Entities;
using Bibliotech.Domain.Repositories;

public class FakeMemberRepository : IMemberRepository
{
    public List<Member> Members = new();

    public Task AddAsync(Member member)
    {
        Members.Add(member);
        return Task.CompletedTask;
    }

    public Task<IEnumerable<Member>> GetAllAsync() =>
        Task.FromResult(Members.AsEnumerable());

    public Task<Member?> GetByIdAsync(int id) =>
        Task.FromResult(Members.FirstOrDefault(m => m.Id == id));

    public Task SaveChangesAsync() => Task.CompletedTask;
}
