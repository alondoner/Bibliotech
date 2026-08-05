namespace Bibliotech.Domain.Entities
{
    public class Member
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string Prenom { get; set; } = string.Empty;

        public MemberProfileType Profil { get; set; }

        public int MaxEmpruntsSimultanes { get; set; }
        public int DureePretJours { get; set; }
    }
}
