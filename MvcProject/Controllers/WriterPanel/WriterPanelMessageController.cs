using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers.WriterPanel
{
    public class WriterPanelMessageController : Controller
    {
        // GET: WriterPanelMessage
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messaValidator = new MessageValidator();
        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];
            var messagelist = messageManager.GetListInbox(p);
            return View(messagelist);
        }
        public ActionResult Sendbox()
        {
            string p = (string)Session["WriterMail"];
            var messagelist = messageManager.GetListSendbox(p);
            return View(messagelist);
        }
        public PartialViewResult WriterMessagePartial()
        {
            return PartialView();
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
        public ActionResult NewMessage(Message p)
        {
            string sender = (string)Session["WriterMail"];
            ValidationResult results = messaValidator.Validate(p);
            if (results.IsValid)
            {
                p.SenderMail = sender;
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
            return View();
        }

    }
}