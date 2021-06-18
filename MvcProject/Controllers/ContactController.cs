using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        Context context = new Context();
        ContactManager contactManager = new ContactManager(new EfContactDal());
        ContactValidator validationRules = new ContactValidator();
        
        public ActionResult Index()
        {
            var contactvalues = contactManager.GetList();
            return View(contactvalues);
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactvalues = contactManager.GetByID(id);
            return View(contactvalues);
        }
        public PartialViewResult ContactPartial()
        {
            
            var receiverMail = context.Messages.Count(x => x.ReceiverMail == "admin@gmail.com").ToString();
            ViewBag.receivermail = receiverMail;
            
            var senderMail = context.Messages.Count(x => x.SenderMail == "admin@gmail.com").ToString();
            ViewBag.senderMail = senderMail;

            var contacMail = context.Contacts.Count().ToString();
            ViewBag.contacMail = contacMail;
            
            var draft = context.Messages.Count(x => x.MessageDraft == true).ToString();
            ViewBag.draft = draft;
            var isRead = context.Messages.Count(x => x.ReceiverMail == "Ceylan@gmail.com"&& x.IsRead == false).ToString();
            ViewBag.isRead = isRead;
            return PartialView();
        }
        
    }
}