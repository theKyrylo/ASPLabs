using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Models;

public class Contact
{   
    [HiddenInput]
    public int Id { get; set; }
    
    [Required(ErrorMessage ="Proszę podać imię!")]
    public string FirstName { get; set; }
    
    [Required(ErrorMessage ="Proszę podać nazwisko!")]
    public string LastName { get; set; }
    
    [RegularExpression(".+\\@.+\\.[a-z]{2,3}")]
    [Required(ErrorMessage ="Proszę podać poprawny email!")]
    public string Email { get; set; }
    
    [Phone]
    [Required(ErrorMessage ="Proszę podać poprawny numer telefonu!")]
    public string PhoneNumber { get; set; }
    
    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Proszę podać poprawną datę urodzenia!")]
    public DateTime DateOfBirth { get; set; }
}