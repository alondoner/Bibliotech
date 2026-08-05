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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Member>().HasData(
                new Member { Id = 1, Nom = "Martin", Prenom = "Alice", Profil = MemberProfileType.Standard, MaxEmpruntsSimultanes = 3, DureePretJours = 21 },
                new Member { Id = 2, Nom = "Dupont", Prenom = "Thomas", Profil = MemberProfileType.Etudiant, MaxEmpruntsSimultanes = 5, DureePretJours = 28 },
                new Member { Id = 3, Nom = "Bernard", Prenom = "Julie", Profil = MemberProfileType.Standard, MaxEmpruntsSimultanes = 3, DureePretJours = 21 },
                new Member { Id = 4, Nom = "Petit", Prenom = "Lucas", Profil = MemberProfileType.Standard, MaxEmpruntsSimultanes = 3, DureePretJours = 21 },
                new Member { Id = 5, Nom = "Robert", Prenom = "Emma", Profil = MemberProfileType.Etudiant, MaxEmpruntsSimultanes = 5, DureePretJours = 28 },
                new Member { Id = 6, Nom = "Richard", Prenom = "Louis", Profil = MemberProfileType.Standard, MaxEmpruntsSimultanes = 3, DureePretJours = 21 },
                new Member { Id = 7, Nom = "Durand", Prenom = "Camille", Profil = MemberProfileType.Etudiant, MaxEmpruntsSimultanes = 5, DureePretJours = 28 },
                new Member { Id = 8, Nom = "Moreau", Prenom = "Hugo", Profil = MemberProfileType.Standard, MaxEmpruntsSimultanes = 3, DureePretJours = 21 },
                new Member { Id = 9, Nom = "Simon", Prenom = "Chloe", Profil = MemberProfileType.Etudiant, MaxEmpruntsSimultanes = 5, DureePretJours = 28 },
                new Member { Id = 10, Nom = "Laurent", Prenom = "Nathan", Profil = MemberProfileType.Standard, MaxEmpruntsSimultanes = 3, DureePretJours = 21 },
                new Member { Id = 11, Nom = "Michel", Prenom = "Sarah", Profil = MemberProfileType.Standard, MaxEmpruntsSimultanes = 3, DureePretJours = 21 },
                new Member { Id = 12, Nom = "Garcia", Prenom = "Antoine", Profil = MemberProfileType.Etudiant, MaxEmpruntsSimultanes = 5, DureePretJours = 28 },
                new Member { Id = 13, Nom = "David", Prenom = "Manon", Profil = MemberProfileType.Standard, MaxEmpruntsSimultanes = 3, DureePretJours = 21 },
                new Member { Id = 14, Nom = "Bertrand", Prenom = "Paul", Profil = MemberProfileType.Etudiant, MaxEmpruntsSimultanes = 5, DureePretJours = 28 },
                new Member { Id = 15, Nom = "Roux", Prenom = "Lea", Profil = MemberProfileType.Standard, MaxEmpruntsSimultanes = 3, DureePretJours = 21 },
                new Member { Id = 16, Nom = "Vincent", Prenom = "Mathieu", Profil = MemberProfileType.Standard, MaxEmpruntsSimultanes = 3, DureePretJours = 21 },
                new Member { Id = 17, Nom = "Fournier", Prenom = "Clara", Profil = MemberProfileType.Etudiant, MaxEmpruntsSimultanes = 5, DureePretJours = 28 },
                new Member { Id = 18, Nom = "Girard", Prenom = "Julien", Profil = MemberProfileType.Standard, MaxEmpruntsSimultanes = 3, DureePretJours = 21 },
                new Member { Id = 19, Nom = "Andre", Prenom = "Lucie", Profil = MemberProfileType.Etudiant, MaxEmpruntsSimultanes = 5, DureePretJours = 28 },
                new Member { Id = 20, Nom = "Mercier", Prenom = "Baptiste", Profil = MemberProfileType.Standard, MaxEmpruntsSimultanes = 3, DureePretJours = 21 }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Titre = "Le Petit Prince", Auteur = "Antoine de Saint-Exupery", NombreExemplairesTotal = 5, NombreExemplairesDisponibles = 5 },
                new Book { Id = 2, Titre = "L'Etranger", Auteur = "Albert Camus", NombreExemplairesTotal = 3, NombreExemplairesDisponibles = 3 },
                new Book { Id = 3, Titre = "Les Miserables", Auteur = "Victor Hugo", NombreExemplairesTotal = 6, NombreExemplairesDisponibles = 6 },
                new Book { Id = 4, Titre = "Madame Bovary", Auteur = "Gustave Flaubert", NombreExemplairesTotal = 2, NombreExemplairesDisponibles = 2 },
                new Book { Id = 5, Titre = "Germinal", Auteur = "Emile Zola", NombreExemplairesTotal = 4, NombreExemplairesDisponibles = 4 },
                new Book { Id = 6, Titre = "La Peste", Auteur = "Albert Camus", NombreExemplairesTotal = 5, NombreExemplairesDisponibles = 5 },
                new Book { Id = 7, Titre = "Notre-Dame de Paris", Auteur = "Victor Hugo", NombreExemplairesTotal = 3, NombreExemplairesDisponibles = 3 },
                new Book { Id = 8, Titre = "Candide", Auteur = "Voltaire", NombreExemplairesTotal = 4, NombreExemplairesDisponibles = 4 },
                new Book { Id = 9, Titre = "Bel-Ami", Auteur = "Guy de Maupassant", NombreExemplairesTotal = 2, NombreExemplairesDisponibles = 2 },
                new Book { Id = 10, Titre = "Le Rouge et le Noir", Auteur = "Stendhal", NombreExemplairesTotal = 5, NombreExemplairesDisponibles = 5 },
                new Book { Id = 11, Titre = "Voyage au centre de la Terre", Auteur = "Jules Verne", NombreExemplairesTotal = 4, NombreExemplairesDisponibles = 4 },
                new Book { Id = 12, Titre = "Vingt mille lieues sous les mers", Auteur = "Jules Verne", NombreExemplairesTotal = 6, NombreExemplairesDisponibles = 6 },
                new Book { Id = 13, Titre = "Le Comte de Monte-Cristo", Auteur = "Alexandre Dumas", NombreExemplairesTotal = 3, NombreExemplairesDisponibles = 3 },
                new Book { Id = 14, Titre = "Les Trois Mousquetaires", Auteur = "Alexandre Dumas", NombreExemplairesTotal = 5, NombreExemplairesDisponibles = 5 },
                new Book { Id = 15, Titre = "La Condition humaine", Auteur = "Andre Malraux", NombreExemplairesTotal = 2, NombreExemplairesDisponibles = 2 },
                new Book { Id = 16, Titre = "Thérèse Raquin", Auteur = "Emile Zola", NombreExemplairesTotal = 4, NombreExemplairesDisponibles = 4 },
                new Book { Id = 17, Titre = "Le Pere Goriot", Auteur = "Honore de Balzac", NombreExemplairesTotal = 5, NombreExemplairesDisponibles = 5 },
                new Book { Id = 18, Titre = "Illusions perdues", Auteur = "Honore de Balzac", NombreExemplairesTotal = 3, NombreExemplairesDisponibles = 3 },
                new Book { Id = 19, Titre = "1984", Auteur = "George Orwell", NombreExemplairesTotal = 4, NombreExemplairesDisponibles = 4 },
                new Book { Id = 20, Titre = "Dune", Auteur = "Frank Herbert", NombreExemplairesTotal = 2, NombreExemplairesDisponibles = 2 }
            );
        }
    }
}
