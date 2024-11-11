using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models;

[Table("contact")]
public class ContactEntity
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }
    
    public string Email { get; set; }
    
    [MaxLength(12)]
    [MinLength(9)]
    public string PhoneNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Priority Priority { get; set; }
    
    public DateTime CreatedOn { get; set; }
}