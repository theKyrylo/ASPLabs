using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class CalculatorController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Result(Calculator model)
    {
        if (!model.IsValid())
        {
            return View("CustomError");
        }
        return View(model);
    }
    
    public IActionResult Form()
    {
        return View();
    }
}