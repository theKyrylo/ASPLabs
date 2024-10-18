using Microsoft.AspNetCore.Mvc;

namespace WebApp.Models;

public class Birth
{
    public string? Name { get; set; }
    public DateTime DateOfBirth { get; set; }

    public bool IsValid()
    {
        return Name != null && DateOfBirth != DateTime.MinValue;
    }

    public int GetAge()
    {
        var now = DateTime.Now;
        var age = now.Year - DateOfBirth.Year;
        if (DateOfBirth > now.AddYears(-age)) age--;
        return age;
    }
}