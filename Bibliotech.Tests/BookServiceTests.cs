using Bibliotech.Domain.Entities;
using Bibliotech.Domain.Services;
using Xunit;

public class BookServiceTests
{
    [Fact]
    public async Task AddBook_Duplicate_Throws()
    {
        var repo = new FakeBookRepository();
        repo.Books.Add(new Book { Titre = "Dune", Auteur = "Herbert" });

        var service = new BookService(repo);

        var newBook = new Book { Titre = "Dune", Auteur = "Herbert" };

        await Assert.ThrowsAsync<Exception>(() => service.AddAsync(newBook));
    }
}
