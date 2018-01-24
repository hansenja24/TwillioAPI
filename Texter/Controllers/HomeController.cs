using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Texter.Models;
using Texter.ViewModels;

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

        public IActionResult SendMultiMessages()
        {
            ViewBag.To = db.Contacts;
            return View();
        }

        [HttpPost]
        public IActionResult SendMultiMessages(GroupMessagesModel newMessages)
        {
            if (newMessages.Contacts.Count > 0)
            {
                foreach (var contact in newMessages.Contacts)
                {
                    newMessages.Message.To = contact;
                    newMessages.Message.Send();
                }
            }
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