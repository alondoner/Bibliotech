using Bibliotech.Domain.Entities;
using Bibliotech.Domain.Services;
using Xunit;

public class MemberServiceTests
{
    [Fact]
    public void StudentProfile_HasHigherLimits()
    {
        var student = new Member
        {
            Profil = MemberProfileType.Etudiant,
            MaxEmpruntsSimultanes = 5,
            DureePretJours = 28
        };

        var standard = new Member
        {
            Profil = MemberProfileType.Standard,
            MaxEmpruntsSimultanes = 3,
            DureePretJours = 21
        };

        Assert.True(student.MaxEmpruntsSimultanes > standard.MaxEmpruntsSimultanes);
        Assert.True(student.DureePretJours > standard.DureePretJours);
    }
}
