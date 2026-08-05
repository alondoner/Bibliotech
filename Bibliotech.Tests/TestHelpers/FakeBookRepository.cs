using Bibliotech.Domain.Entities;
using Bibliotech.Domain.Repositories;

public class FakeBookRepository : IBookRepository
{
    public List<Book> Books = new();

    public Task AddAsync(Book book)
    {
        Books.Add(book);
        return Task.CompletedTask;
    }

    public Task<IEnumerable<Book>> GetAllAsync() =>
        Task.FromResult(Books.AsEnumerable());

    public Task<Book?> GetByIdAsync(int id) =>
        Task.FromResult(Books.FirstOrDefault(b => b.Id == id));

    public Task UpdateAsync(Book book) => Task.CompletedTask;

    public Task SaveChangesAsync() => Task.CompletedTask;

    public Task<bool> ExistsAsync(Book book)
    {
        return Task.FromResult(
            Books.Any(b =>
                b.Titre.ToLower() == book.Titre.ToLower() &&
                b.Auteur.ToLower() == book.Auteur.ToLower()
            )
        );
    }
}
