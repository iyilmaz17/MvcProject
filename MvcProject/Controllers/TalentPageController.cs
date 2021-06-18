using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
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
    }
}