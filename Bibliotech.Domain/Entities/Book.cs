namespace Bibliotech.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Titre { get; set; } = string.Empty;
        public string Auteur { get; set; } = string.Empty;

        public int NombreExemplairesTotal { get; set; }
        public int NombreExemplairesDisponibles { get; set; }

        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}

