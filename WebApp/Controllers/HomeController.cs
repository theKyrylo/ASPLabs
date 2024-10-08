using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult About()
    {
        return View();
    }
    
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Calculator(Operator? operation, double? a, double? b)
    {
        if (a is null || b is null)
        {
            ViewBag.ErrorMessage = "Niepoprawny format liczby w parametrze a lub b";
            return View("CustomError");   
        }
        ViewBag.a = a;
        ViewBag.b = b;
        switch (operation)
        {
            case Operator.Add:
                ViewBag.result = a + b;
                ViewBag.operation = "+";
                break;
            case Operator.Sub:
                ViewBag.result = a - b;
                ViewBag.operation = "-";
                break;
            case Operator.Mul:
                ViewBag.result = a * b;
                ViewBag.operation = "*";
                break;
            case Operator.Div:
                ViewBag.result = a / b;
                ViewBag.operation = ":";
                break;
            default:
                ViewBag.ErrorMessage = "Nieznany operator";
                return View("CustomError");
        }
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public enum Operator
    {
        Add, Sub, Mul, Div
    }
}