using Bibliotech.Domain.Entities;
using Bibliotech.Domain.Services;
using Xunit;

public class LoanServiceTests
{
    private FakeBookRepository books = new();
    private FakeMemberRepository members = new();
    private FakeLoanRepository loans = new();

    private LoanService CreateService() =>
        new LoanService(loans, books, members);

    // --- Cas normal ---
    [Fact]
    public async Task Borrow_NormalCase()
    {
        books.Books.Add(new Book { Id = 1, Titre = "Dune", Auteur = "Herbert", NombreExemplairesDisponibles = 1 });
        members.Members.Add(new Member { Id = 1, Profil = MemberProfileType.Standard, MaxEmpruntsSimultanes = 3, DureePretJours = 21 });

        var service = CreateService();
        var loan = await service.BorrowAsync(1, 1);

        Assert.NotNull(loan);
        Assert.Equal(1, books.Books[0].NombreExemplairesDisponibles);
    }

    // --- Quota atteint ---
    [Fact]
    public async Task Borrow_QuotaReached()
    {
        books.Books.Add(new Book { Id = 1, NombreExemplairesDisponibles = 1 });
        members.Members.Add(new Member { Id = 1, MaxEmpruntsSimultanes = 1, DureePretJours = 21 });

        loans.Loans.Add(new Loan { MemberId = 1, BookId = 1, DateRetour = null });

        var service = CreateService();

        await Assert.ThrowsAsync<Exception>(() => service.BorrowAsync(1, 1));
    }

    // --- Pas d'exemplaire ---
    [Fact]
    public async Task Borrow_NoCopiesAvailable()
    {
        books.Books.Add(new Book { Id = 1, NombreExemplairesDisponibles = 0 });
        members.Members.Add(new Member { Id = 1, MaxEmpruntsSimultanes = 3 });

        var service = CreateService();

        await Assert.ThrowsAsync<Exception>(() => service.BorrowAsync(1, 1));
    }

    // --- Retour sans retard ---
    [Fact]
    public async Task Return_NoLate()
    {
        var book = new Book { Id = 1, NombreExemplairesDisponibles = 0 };
        books.Books.Add(book);

        var loan = new Loan
        {
            Id = 1,
            Book = book,
            DateEcheance = DateTime.UtcNow,
            DateEmprunt = DateTime.UtcNow.AddDays(-10)
        };

        loans.Loans.Add(loan);

        var service = CreateService();
        var result = await service.ReturnAsync(1);

        Assert.Equal(0, result.MontantPenalite);
    }

    // --- Retour avec retard ---
    [Fact]
    public async Task Return_WithLate()
    {
        var book = new Book { Id = 1, NombreExemplairesDisponibles = 0 };
        books.Books.Add(book);

        var loan = new Loan
        {
            Id = 1,
            Book = book,
            DateEcheance = DateTime.UtcNow.AddDays(-5)
        };

        loans.Loans.Add(loan);

        var service = CreateService();
        var result = await service.ReturnAsync(1);

        Assert.True(result.MontantPenalite > 0);
    }

    // --- Plafonnement ---
    [Fact]
    public async Task Return_PenaltyCapped()
    {
        var book = new Book { Id = 1, NombreExemplairesDisponibles = 0 };
        books.Books.Add(book);

        var loan = new Loan
        {
            Id = 1,
            Book = book,
            DateEcheance = DateTime.UtcNow.AddDays(-200)
        };

        loans.Loans.Add(loan);

        var service = CreateService();
        var result = await service.ReturnAsync(1);

        Assert.Equal(10m, result.MontantPenalite);
    }

    // --- Retour le jour exact ---
    [Fact]
    public async Task Return_ExactDay_NoPenalty()
    {
        var book = new Book { Id = 1, NombreExemplairesDisponibles = 0 };
        books.Books.Add(book);

        var loan = new Loan
        {
            Id = 1,
            Book = book,
            DateEcheance = DateTime.UtcNow
        };

        loans.Loans.Add(loan);

        var service = CreateService();
        var result = await service.ReturnAsync(1);

        Assert.Equal(0m, result.MontantPenalite);
    }
}
