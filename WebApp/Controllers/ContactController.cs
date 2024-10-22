using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class ContactController : Controller
{
	private static Dictionary<int, ContactModel> _contacts = new();
    public IActionResult Index()
    {
        return View();
    }
    
    public ActionResult Add()
    {
		return View();
	}
	[HttpPost]
	public ActionResult Add(ContactModel model)
	{
		if(!ModelState.IsValid)
			return View();
		return View("Index");
	}
}