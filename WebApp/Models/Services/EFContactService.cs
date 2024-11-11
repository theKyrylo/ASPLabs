namespace WebApp.Models.Services;

public class EfContactService : IContactService
{
    private readonly AppDbContext _context;
    public EfContactService(AppDbContext context) => _context = context;
    public void AddContact(Contact contact)
    {
        _context.Contacts.Add(ContactMapper.ToEntity(contact));
        _context.SaveChanges();
    }

    public void EditContact(Contact contact)
    {
       _context.Contacts.Update(ContactMapper.ToEntity(contact));
       _context.SaveChanges();
    }

    public void DeleteContact(int id)
    {
        throw new NotImplementedException();
    }

    public List<Contact> GetContacts()
    {
        return _context.Contacts.Select(e=>ContactMapper.FromEntity(e)).ToList();
    }

    public Contact? GetContactById(int id)
    {
        var entity = _context.Contacts.Find(id);
        return entity != null ? ContactMapper.FromEntity(entity) : null;
    }
}