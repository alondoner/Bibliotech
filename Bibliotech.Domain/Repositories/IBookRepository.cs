using Bibliotech.Domain.Entities;

namespace Bibliotech.Domain.Repositories
{
    public interface IBookRepository
    {
        Task<Book?> GetByIdAsync(int id);
        Task<IEnumerable<Book>> GetAllAsync();
        Task AddAsync(Book book);
        Task UpdateAsync(Book book);
        Task<bool> ExistsAsync(Book book);
        Task SaveChangesAsync();
    }
}
