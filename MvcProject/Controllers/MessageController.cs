using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messaValidator = new MessageValidator();
        [Authorize]
        public ActionResult Inbox(string p)
        {
            var messagelist = messageManager.GetListInbox(p);
            return View(messagelist);
        }
        public ActionResult Sendbox(string p)
        {
            var messagelist = messageManager.GetListSendbox(p);
            return View(messagelist);
        }
        public ActionResult GetInBoxDetails(int id)
        {
            var values = messageManager.GetByID(id);
            return View(values);
        }
        public ActionResult GetSendBoxDetails(int id)
        {
            var values = messageManager.GetByID(id);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p, string button)
        {
            if (button == "Save")
            {
                ValidationResult results = messaValidator.Validate(p);
                if (results.IsValid)
                {
                    p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    messageManager.MessageAdd(p);
                    return RedirectToAction("Sendbox");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            else if (button == "Send")
            {
                ValidationResult results = messaValidator.Validate(p);
                if (results.IsValid)
                {
                    p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    p.MessageDraft = true;
                    p.SenderMail = "admin@gmail.com";
                    messageManager.MessageAdd(p);
                    return RedirectToAction("MessageDraft");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult NewDraft(Message p)
        {
            p.SenderMail = "admin@gmail.com";
            p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            messageManager.MessageAdd(p);
            return RedirectToAction("Sendbox");
        }
        public ActionResult MessageDraft(string p)
        {
            var drafList = messageManager.GetListInbox(p).FindAll(x => x.MessageDraft == true);
            return View(drafList);

        }
        public ActionResult MessageDraftDetails(int id)
        {
            var values = messageManager.GetByID(id);
            return View(values);
        }
        public ActionResult MessageIsRead(int id)
        {
            var result = messageManager.GetByID(id);
            if (result.IsRead==false)
            {
                result.IsRead = true;
            }
            else
            {
                result.IsRead = false;
            }
            messageManager.MessageUpdate(result);
            return RedirectToAction("Inbox");
        }
        public ActionResult MessageRead(string p)
        {
            var result = messageManager.GetListInbox(p).Where(x => x.IsRead == true).ToList();
            return View(result);
        }
        public  ActionResult MessageUnRead()
        {
            var result = messageManager.GetAllRead();
            return View(result);
        }
    }
}