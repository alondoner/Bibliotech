using Bibliotech.Domain.Entities;
using Bibliotech.Domain.Repositories;

namespace Bibliotech.Domain.Services
{
    public class BookService
    {
        private readonly IBookRepository _books;

        public BookService(IBookRepository books)
        {
            _books = books;
        }

        public Task<IEnumerable<Book>> GetAllAsync() => _books.GetAllAsync();

        public Task<Book?> GetByIdAsync(int id) => _books.GetByIdAsync(id)
                ?? throw new Exception("Livre introuvable");

        public async Task AddAsync(Book book)
        {
            if (await _books.ExistsAsync(book))
                throw new Exception("Ce livre existe déjà dans le catalogue.");

            await _books.AddAsync(book);
            await _books.SaveChangesAsync();
        }
    }
}
