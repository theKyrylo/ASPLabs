using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models;

[Table("organizations")]
public class OrganizationEntity
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Region { get; set; }
    public string NIP { get; set; }
    public Address? Address { get; set; }             // klasa osadzona - brak osobnej tabeli
    public ISet<ContactEntity> Contacts { get; set; } // navigation property - osobna tabela
}

public class Address
{
    public string City { get; set; }
    public string Street { get; set; }
}