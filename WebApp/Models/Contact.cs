using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Models;

public class Contact
{   
    [HiddenInput]
    public int Id { get; set; }
    
    [Display(Name = "Imię")]
    [Required(ErrorMessage ="Proszę podać imię!")]
    public string FirstName { get; set; }
    
    [Display(Name = "Nazwisko")]
    [Required(ErrorMessage ="Proszę podać nazwisko!")]
    public string LastName { get; set; }
    
    [Display(Name = "Email")]
    [RegularExpression(".+\\@.+\\.[a-z]{2,3}")]
    [Required(ErrorMessage ="Proszę podać poprawny email!")]
    public string Email { get; set; }
    
    [Display(Name = "Numer telefonu")]
    [Phone]
    [Required(ErrorMessage ="Proszę podać poprawny numer telefonu!")]
    public string PhoneNumber { get; set; }
    
    [Display(Name = "Data urodzenia")]
    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Proszę podać poprawną datę urodzenia!")]
    public DateTime DateOfBirth { get; set; }
    
    [Display(Name = "Priorytet")]
    public Priority Priority { get; set; }
    
    [HiddenInput] public int OrganizationId { get; set; }
    [ValidateNever] public List<SelectListItem>? Organizations { get; set; }
}