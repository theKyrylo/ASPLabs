using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class BirthController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Result([FromForm] Birth model)
    {
        if (!model.IsValid())
        {
            return View("Error");
        }
        return View(model);
    }
    
    public IActionResult Form()
    {
        return View();
    }
}