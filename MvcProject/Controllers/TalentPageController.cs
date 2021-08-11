using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class TalentPageController : Controller
    {
        // GET: TalentPage
        TalentLevelManager talentLevelManager = new TalentLevelManager(new EfTalentLevelDal());
        public ActionResult Index()
        {
            var result = talentLevelManager.GetList();
            return View(result);
        }
        [HttpGet]
        public ActionResult AddTalent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTalent(TalentLevel talentLevel)
        {
            talentLevelManager.Add(talentLevel);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateTalent(int id)
        {
            var cardValues = talentLevelManager.GetByID(id);
            return View(cardValues);
        }

        [HttpPost]
        public ActionResult UpdateTalent(TalentLevel talentLevel)
        {
            talentLevelManager.Update(talentLevel);
            return RedirectToAction("Index");
        }
    }
}