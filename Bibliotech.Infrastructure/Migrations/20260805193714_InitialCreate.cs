using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bibliotech.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titre = table.Column<string>(type: "TEXT", nullable: false),
                    Auteur = table.Column<string>(type: "TEXT", nullable: false),
                    NombreExemplairesTotal = table.Column<int>(type: "INTEGER", nullable: false),
                    NombreExemplairesDisponibles = table.Column<int>(type: "INTEGER", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "BLOB", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", nullable: false),
                    Prenom = table.Column<string>(type: "TEXT", nullable: false),
                    Profil = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxEmpruntsSimultanes = table.Column<int>(type: "INTEGER", nullable: false),
                    DureePretJours = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MemberId = table.Column<int>(type: "INTEGER", nullable: false),
                    BookId = table.Column<int>(type: "INTEGER", nullable: false),
                    DateEmprunt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateEcheance = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateRetour = table.Column<DateTime>(type: "TEXT", nullable: true),
                    MontantPenalite = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loans_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Loans_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Auteur", "NombreExemplairesDisponibles", "NombreExemplairesTotal", "RowVersion", "Titre" },
                values: new object[,]
                {
                    { 1, "Antoine de Saint-Exupery", 5, 5, new byte[0], "Le Petit Prince" },
                    { 2, "Albert Camus", 3, 3, new byte[0], "L'Etranger" },
                    { 3, "Victor Hugo", 6, 6, new byte[0], "Les Miserables" },
                    { 4, "Gustave Flaubert", 2, 2, new byte[0], "Madame Bovary" },
                    { 5, "Emile Zola", 4, 4, new byte[0], "Germinal" },
                    { 6, "Albert Camus", 5, 5, new byte[0], "La Peste" },
                    { 7, "Victor Hugo", 3, 3, new byte[0], "Notre-Dame de Paris" },
                    { 8, "Voltaire", 4, 4, new byte[0], "Candide" },
                    { 9, "Guy de Maupassant", 2, 2, new byte[0], "Bel-Ami" },
                    { 10, "Stendhal", 5, 5, new byte[0], "Le Rouge et le Noir" },
                    { 11, "Jules Verne", 4, 4, new byte[0], "Voyage au centre de la Terre" },
                    { 12, "Jules Verne", 6, 6, new byte[0], "Vingt mille lieues sous les mers" },
                    { 13, "Alexandre Dumas", 3, 3, new byte[0], "Le Comte de Monte-Cristo" },
                    { 14, "Alexandre Dumas", 5, 5, new byte[0], "Les Trois Mousquetaires" },
                    { 15, "Andre Malraux", 2, 2, new byte[0], "La Condition humaine" },
                    { 16, "Emile Zola", 4, 4, new byte[0], "Thérèse Raquin" },
                    { 17, "Honore de Balzac", 5, 5, new byte[0], "Le Pere Goriot" },
                    { 18, "Honore de Balzac", 3, 3, new byte[0], "Illusions perdues" },
                    { 19, "George Orwell", 4, 4, new byte[0], "1984" },
                    { 20, "Frank Herbert", 2, 2, new byte[0], "Dune" }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "DureePretJours", "MaxEmpruntsSimultanes", "Nom", "Prenom", "Profil" },
                values: new object[,]
                {
                    { 1, 21, 3, "Martin", "Alice", 1 },
                    { 2, 28, 5, "Dupont", "Thomas", 2 },
                    { 3, 21, 3, "Bernard", "Julie", 1 },
                    { 4, 21, 3, "Petit", "Lucas", 1 },
                    { 5, 28, 5, "Robert", "Emma", 2 },
                    { 6, 21, 3, "Richard", "Louis", 1 },
                    { 7, 28, 5, "Durand", "Camille", 2 },
                    { 8, 21, 3, "Moreau", "Hugo", 1 },
                    { 9, 28, 5, "Simon", "Chloe", 2 },
                    { 10, 21, 3, "Laurent", "Nathan", 1 },
                    { 11, 21, 3, "Michel", "Sarah", 1 },
                    { 12, 28, 5, "Garcia", "Antoine", 2 },
                    { 13, 21, 3, "David", "Manon", 1 },
                    { 14, 28, 5, "Bertrand", "Paul", 2 },
                    { 15, 21, 3, "Roux", "Lea", 1 },
                    { 16, 21, 3, "Vincent", "Mathieu", 1 },
                    { 17, 28, 5, "Fournier", "Clara", 2 },
                    { 18, 21, 3, "Girard", "Julien", 1 },
                    { 19, 28, 5, "Andre", "Lucie", 2 },
                    { 20, 21, 3, "Mercier", "Baptiste", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Loans_BookId",
                table: "Loans",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_MemberId",
                table: "Loans",
                column: "MemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
