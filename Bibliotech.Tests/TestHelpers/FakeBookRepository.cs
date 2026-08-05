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

    public Task<bool> ExistsAsync(string titre, string auteur)
    {
        return Task.FromResult(
            Books.Any(b =>
                b.Titre.ToLower() == titre.ToLower() &&
                b.Auteur.ToLower() == auteur.ToLower()
            )
        );
    }
}
