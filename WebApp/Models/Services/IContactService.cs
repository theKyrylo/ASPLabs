namespace WebApp.Models.Services;

public interface IContactService
{
    void AddContact(Contact contact);
    void EditContact(Contact contact);
    void DeleteContact(int id);
    List<Contact> GetContacts();
    Contact? GetContactById(int id);
    
    List<OrganizationEntity> GetOrganizations();
}