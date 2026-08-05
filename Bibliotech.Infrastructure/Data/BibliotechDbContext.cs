namespace Bibliotech.Infrastructure.Data
{
    using Microsoft.EntityFrameworkCore;
    using Bibliotech.Domain.Entities;

    public class BibliotechDbContext : DbContext
    {
        public DbSet<Book> Books => Set<Book>();
        public DbSet<Member> Members => Set<Member>();
        public DbSet<Loan> Loans => Set<Loan>();

        public BibliotechDbContext(DbContextOptions<BibliotechDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .Property(b => b.RowVersion)
                .IsRowVersion();
        }
    }
}
