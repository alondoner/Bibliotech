using Bibliotech.Domain.Entities;
using Bibliotech.Domain.Repositories;

namespace Bibliotech.Domain.Services
{
    public class LoanService
    {
        private readonly ILoanRepository _loans;
        private readonly IBookRepository _books;
        private readonly IMemberRepository _members;

        public LoanService(ILoanRepository loans, IBookRepository books, IMemberRepository members)
        {
            _loans = loans;
            _books = books;
            _members = members;
        }

        public async Task<Loan> BorrowAsync(int memberId, int bookId)
        {
            var member = await _members.GetByIdAsync(memberId)
                ?? throw new Exception("Adhérent introuvable");

            var book = await _books.GetByIdAsync(bookId)
                ?? throw new Exception("Livre introuvable");

            if (book.NombreExemplairesDisponibles <= 0)
                throw new Exception("Aucun exemplaire disponible");

            var loans = await _loans.GetLoansByMemberAsync(memberId);
            if (loans.Count(l => l.DateRetour == null) >= member.MaxEmpruntsSimultanes)
                throw new Exception("Quota d'emprunts atteint");

            var loan = new Loan
            {
                MemberId = memberId,
                BookId = bookId,
                DateEmprunt = DateTime.UtcNow,
                DateEcheance = DateTime.UtcNow.AddDays(member.DureePretJours)
            };

            book.NombreExemplairesDisponibles--;

            await _loans.AddAsync(loan);
            await _books.UpdateAsync(book);

            await _loans.SaveChangesAsync();
            await _books.SaveChangesAsync();

            return loan;
        }

        public async Task<Loan> ReturnAsync(int loanId)
        {
            var loan = await _loans.GetByIdAsync(loanId)
                ?? throw new Exception("Emprunt introuvable");

            if (loan.DateRetour != null)
                throw new Exception("Déjà retourné");

            loan.DateRetour = DateTime.UtcNow;

            var delay = (loan.DateRetour.Value - loan.DateEcheance).TotalDays;
            var daysLate = Math.Max(0, (int)delay);

            loan.MontantPenalite = Math.Min(daysLate * 0.20m, 10m);

            if (loan.Book != null)
                loan.Book.NombreExemplairesDisponibles++;

            await _loans.SaveChangesAsync();
            await _books.SaveChangesAsync();

            return loan;
        }

        public async Task<IEnumerable<Loan>> GetLoansByMemberAsync(int memberId)
        {
            return await _loans.GetLoansByMemberAsync(memberId);
        }
    }
}
