using Microsoft.EntityFrameworkCore;

namespace WebApp.Models;

public class AppDbContext : DbContext
{
    public DbSet<ContactEntity> Contacts { get; set; }
    
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
        modelBuilder.Entity<ContactEntity>().HasData(
            new ContactEntity() { Id = 1, FirstName = "Adam", LastName = "Kowalski", Email = "adam@wsei.edu.pl", PhoneNumber = "127813268163", DateOfBirth = new DateTime(2000,10,10),  Priority = Priority.Normal, CreatedOn = DateTime.Now },
            new ContactEntity() { Id = 2, FirstName = "Ewa", LastName = "Kowalska", Email = "ewa@wsei.edu.pl", PhoneNumber = "293443823478", DateOfBirth = new DateTime(1999, 8, 10), Priority = Priority.Normal, CreatedOn = DateTime.Now}
        );
    }
}