using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using EntityLayer.Concrete;

namespace MvcProject.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        ImageFileManager imageFileManager = new ImageFileManager(new EfImageFileDal());

        public ActionResult Index()
        {
            var files = imageFileManager.GetList();
            return View(files);
        }
        [HttpGet]
        public ActionResult ImageAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ImageAdd(ImageFile ımageFile)
        {
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string expansion = Path.GetExtension(Request.Files[0].FileName);
                string path = "/Images/" + fileName + expansion;
                Request.Files[0].SaveAs(Server.MapPath(path));
                ımageFile.ImagePath = "/Images/" + fileName + expansion;
                imageFileManager.Add(ımageFile);
                return RedirectToAction("Index");

            }
            return View();

        }
    }
}