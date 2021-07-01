using MvcProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }

        public List<CategoryTest> BlogList()
        {
            List<CategoryTest> categoryTests = new List<CategoryTest>();
            categoryTests.Add(new CategoryTest()
            {
                CategoryName = "Yazılım",
                CategoryCount = 25
            });
            categoryTests.Add(new CategoryTest()
            {
                CategoryName = "Gezi",
                CategoryCount = 15
            });
            categoryTests.Add(new CategoryTest()
            {
                CategoryName = "Spor",
                CategoryCount = 30
            });
            categoryTests.Add(new CategoryTest()
            {
                CategoryName = "Güncel",
                CategoryCount = 45
            });
            return categoryTests;
        }
    }
}