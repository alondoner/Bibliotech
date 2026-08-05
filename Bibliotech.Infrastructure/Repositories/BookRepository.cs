using Bibliotech.Domain.Entities;
using Bibliotech.Domain.Repositories;
using Bibliotech.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Bibliotech.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BibliotechDbContext _context;

        public BookRepository(BibliotechDbContext context)
        {
            _context = context;
        }

        public Task<Book?> GetByIdAsync(int id) =>
            //_context.Books.FirstOrDefaultAsync(b => b.Id == id);
            _context.Books.FindAsync(id).AsTask();

        public Task<IEnumerable<Book>> GetAllAsync() =>
            Task.FromResult(_context.Books.AsEnumerable());

        public async Task AddAsync(Book book)
        {
            await _context.Books.AddAsync(book);
        }

        public Task UpdateAsync(Book book)
        {
            _context.Books.Update(book);
            return Task.CompletedTask;
        }

        public Task<bool> ExistsAsync(Book book)
        {
            return _context.Books
                .AnyAsync(b => b.Titre.ToLower().Equals(book.Titre.ToLower())
                            && b.Auteur.ToLower().Equals(book.Auteur.ToLower()));
        }

        public Task SaveChangesAsync() =>
            _context.SaveChangesAsync();
    }
}
