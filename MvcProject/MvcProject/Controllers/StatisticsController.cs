using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics

        Context context = new Context();
        public ActionResult Index()
        {
            // Toplam Categori
            var TotalCategoryCount = context.Categories.Count();
            ViewBag.Value1 = TotalCategoryCount;
            // Yazılım kategorisi
            var TotalsoftwareTitle = context.Headings.Count(x => x.CategoryID == 25);
            ViewBag.Value2 = TotalsoftwareTitle;
            //İçinde a harfi geçen
            var BetweenCharacter = context.Writers.Count(x => x.WriterName.ToLower().Contains("a"));
            ViewBag.Value3 = BetweenCharacter;
            //En fazla başlığa sahip kategori
            //var MaxTitleCount = context.Headings.Max(x => x.Category.CategoryName);
            //var MaxTitleCount = context.Headings.Select(x=>x.CategoryID== Max(x => x.CategoryID))
            var MaxTitleCount = context.Categories.Where(u => u.CategoryID == context.Headings.GroupBy(x => x.CategoryID).OrderByDescending(x => x.Count()).Select(x => x.Key).FirstOrDefault()).Select(x => x.CategoryName).FirstOrDefault();
            ViewBag.Value4 = MaxTitleCount;
            // Kategori tablosunda durumu true olan kategoriler ile false olan kategoriler arasındaki sayısal fark
            var CategoryStatusDifference = (context.Categories.Count(x=>x.CategoryStatus==true)- context.Categories.Count(x => x.CategoryStatus == false));
            ViewBag.Value5 = CategoryStatusDifference;
            return View();
        }
    }
}