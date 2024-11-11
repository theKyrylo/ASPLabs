using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Models.Services;

namespace WebApp.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            var contacts = _contactService.GetContacts();
            return View(contacts);
        }
        
        [HttpGet]
        public IActionResult ContactForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContactForm(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _contactService.AddContact(contact);
                return RedirectToAction("Index");
            }
            return View(contact);
        }
        
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var contact = _contactService.GetContactById(id);
            if (contact != null)
            {
                return View(contact);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _contactService.EditContact(contact);
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var contact = _contactService.GetContactById(id);
            if (contact != null)
            {
                return View(contact);
            }
            return NotFound();
        }
        
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var contact = _contactService.GetContactById(id);
            if (contact != null)
            {
                return View(contact);
            }
            return NotFound();
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _contactService.DeleteContact(id);
            return RedirectToAction("Index");
        }
    }
}
