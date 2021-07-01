using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers.WriterPanel
{
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent
        ContentManager contentManager = new ContentManager(new EfContentDal());
        Context context = new Context();
        public ActionResult MyContent(string p)
        {
            
            p = (string)Session["WriterMail"];
            var writeridinfo = context.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            // ViewBag.d = p;
            var contentvalues = contentManager.GetListByWriter(writeridinfo);
            return View(contentvalues);
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content p)
        {
            string mail = (string)Session["WriterMail"];
            
            var writeridinfo = context.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterID).FirstOrDefault();
            p.ContentDate=DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterID = writeridinfo;
            p.ContentStatus = true;
            contentManager.ContentAdd(p);
            return RedirectToAction("MyContent");
        }
        public ActionResult ToDoList()
        {
            return View();
        }
    }
}