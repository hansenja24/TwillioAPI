using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Texter.Models;

namespace Texter.Controllers
{
    public class HomeController : Controller
    {
        private TexterDbContext db = new TexterDbContext();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetMessages()
        {
            var allMessages = Message.GetMessages();
            return View(allMessages);
        }

        public IActionResult SendMessage()
        {
            ViewBag.To = new SelectList(db.Contacts, "Number", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(Message newMessage)
        {
            newMessage.Send();
            return RedirectToAction("Index");
        }

        public IActionResult NewContact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewContact(Contact item)
        {
            db.Contacts.Add(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}