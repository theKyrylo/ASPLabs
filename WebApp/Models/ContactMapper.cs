namespace WebApp.Models;

public class ContactMapper
{
    public static Contact FromEntity(ContactEntity entity)
    {
        return new Contact()
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Email = entity.Email,
            PhoneNumber = entity.PhoneNumber,
            DateOfBirth = entity.DateOfBirth,
            Priority = entity.Priority,
            OrganizationId = entity.OrganizationId
        };
    }

    public static ContactEntity ToEntity(Contact contact)
    {
        return new ContactEntity()
        {
            Id = contact.Id,
            FirstName = contact.FirstName,
            LastName = contact.LastName,
            Email = contact.Email,
            PhoneNumber = contact.PhoneNumber,
            DateOfBirth = contact.DateOfBirth,
            Priority = contact.Priority,
            OrganizationId = contact.OrganizationId
        };
    }
}