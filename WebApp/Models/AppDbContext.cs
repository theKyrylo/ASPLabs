using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

namespace WebApp.Models;

public class AppDbContext : IdentityDbContext<IdentityUser>
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
        base.OnModelCreating(modelBuilder);
        
        string ADMIN_ID = Guid.NewGuid().ToString();
        string USER_ID = Guid.NewGuid().ToString();

        modelBuilder.Entity<IdentityRole>()
            .HasData(
                new IdentityRole()
                {
                    Id = ADMIN_ID,
                    Name = "admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = ADMIN_ID
                },
                new IdentityRole()
                {
                    Id = USER_ID,
                    Name = "user",
                    NormalizedName = "USER",
                    ConcurrencyStamp = USER_ID
                }
            );
        var admin = new IdentityUser()
        {
            Id = ADMIN_ID,
            UserName = "Admin",
            NormalizedUserName = "ADMIN",
            Email = "admin@admin.com",
            NormalizedEmail = "ADMIN@ADMIN.COM",
            EmailConfirmed = true
        };
        var user = new IdentityUser()
        {
            Id = USER_ID,
            UserName = "User",
            NormalizedUserName = "USER",
            Email = "user@admin.com",
            NormalizedEmail = "USER@ADMIN.COM",
            EmailConfirmed = true
        };
        
        PasswordHasher<IdentityUser> hasher = new PasswordHasher<IdentityUser>();
        admin.PasswordHash = hasher.HashPassword(admin, "admin");
        user.PasswordHash = hasher.HashPassword(user, "1234!!!");
        
        modelBuilder.Entity<IdentityUser>()
            .HasData(admin, user);

        modelBuilder.Entity<IdentityUserRole<string>>()
            .HasData(
                new IdentityUserRole<string>()
                {
                    RoleId = ADMIN_ID,
                    UserId = ADMIN_ID
                },
                new IdentityUserRole<string>()
                {
                    RoleId = USER_ID,
                    UserId = USER_ID
                }
            );
        
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