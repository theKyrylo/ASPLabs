using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class ContactController : Controller
{
    static Dictionary<int, Contact> _contacts = new();
    
    public IActionResult Index()
    {
        return View(_contacts);
    }
    
    [HttpGet]
    public IActionResult ContactForm(){
        return View("ContactForm");
    }

    [HttpPost]
    public IActionResult ContactForm(Contact contact)
    {
        if (ModelState.IsValid)
        {
            int id = _contacts.Keys.Count != 0 ? _contacts.Keys.Max() : 0;
            contact.Id = id + 1;
            _contacts.Add(contact.Id, contact);

            return RedirectToAction("Index");
        }
        return View(contact);
    }
    
    [HttpGet]
    public IActionResult Edit(int id)
    {
    
        if (_contacts.Keys.Contains(id))
        {
            return View(_contacts[id]);
        }
        else
        {
            return NotFound();
        };
    }
    [HttpPost]
    public IActionResult Edit(Contact contact, int id)
    {
        if (ModelState.IsValid)
        {
            _contacts[id] = contact;
            return RedirectToAction("Index");
        }
        return View(_contacts[id]);
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        return View(_contacts[id]);
    }
    
    //TODO DELETE
    
    [HttpGet]
    public IActionResult Delete()
    {
        throw new NotImplementedException();
    }
    [HttpPost]
    public IActionResult Delete(Contact contact)
    {
        throw new NotImplementedException();
    }
}