using Microsoft.EntityFrameworkCore;

namespace WebApp.Models;

public class AppDbContext : DbContext
{
    public DbSet<ContactEntity> Contacts { get; set; }
    
    public DbSet<OrganizationEntity> Organizations { get; set; }
    private string DbPath { get; set; }
    public AppDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "contacts.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={DbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrganizationEntity>()
            .OwnsOne(o => o.Address)
            .HasData(
                new { OrganizationEntityID = 1, City = "London", Street = "Street"},
                new { OrganizationEntityID = 2, City = "Krakow", Street = "Miodowa"}
                );
        
        modelBuilder.Entity<ContactEntity>()
            .HasOne<OrganizationEntity>(c => c.Organization)
            .WithMany(o => o.Contacts)
            .HasForeignKey(c => c.OrganizationId);

        modelBuilder.Entity<OrganizationEntity>()
            .HasData(
                new OrganizationEntity()
                {
                    ID = 1, Region = "7238492482",
                    NIP = "17268734", Name = "Famo"
                },
                new OrganizationEntity()
                {
                    ID = 2, Region = "7238495672",
                    NIP = "14368734", Name = "Org"
                });
        
        modelBuilder.Entity<ContactEntity>().HasData(
            new ContactEntity() { Id = 1, FirstName = "Adam", LastName = "Kowalski", Email = "adam@wsei.edu.pl", PhoneNumber = "127813268163", DateOfBirth = new DateTime(2000,10,10),  Priority = Priority.Normal, CreatedOn = DateTime.Now, OrganizationId = 1},
            new ContactEntity() { Id = 2, FirstName = "Ewa", LastName = "Kowalska", Email = "ewa@wsei.edu.pl", PhoneNumber = "293443823478", DateOfBirth = new DateTime(1999, 8, 10), Priority = Priority.Normal, CreatedOn = DateTime.Now, OrganizationId = 2}
        );
    }
}