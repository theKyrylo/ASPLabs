namespace WebApp.Models;

public class ContactModel
{
    [HiddenInput]
    public int ID { get; set; }
    
    [Required(ErrormMessage = "You must enter a first name")]
    [MaxLength(length: 20, ErrorMessage = "Too long")]
    public string FirstName { get; set; }
    
    [Required(ErrormMessage = "You must enter a last name")]
    [MaxLength(length: 20, ErrorMessage = "Too long")]
    public string LastName { get; set; }
    
    [EmailAddress()]
    public string Email { get; set; }
    [Phone()]
    public string Phone { get; set; }
    [DataType(Data)]
    public DateOnly BirthDate { get; set; }
}