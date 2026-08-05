namespace Bibliotech.Domain.Entities
{
    public class Loan
    {
        public int Id { get; set; }

        public int MemberId { get; set; }
        public Member? Member { get; set; }

        public int BookId { get; set; }
        public Book? Book { get; set; }

        public DateTime DateEmprunt { get; set; }
        public DateTime DateEcheance { get; set; }
        public DateTime? DateRetour { get; set; }

        public decimal MontantPenalite { get; set; }
    }
}
