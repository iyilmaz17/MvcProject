using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        WriterLoginManager writerLoginManager = new WriterLoginManager(new EfWriterDal());
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            string password = p.AdminPassword;
            string result = Convert.ToBase64String(sha1.ComputeHash(Encoding.UTF8.GetBytes(password)));
            p.AdminPassword = result;

            Context context = new Context();
            var adminUserInfo = context.Admins.FirstOrDefault(x => x.AdminUserName == p.AdminUserName && x.AdminPassword == p.AdminPassword);
            if (adminUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminUserInfo.AdminUserName, false);
                Session["AdminUserName"] = adminUserInfo.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                ViewBag.ErrorMessage = "Kullanıcı adı veya hatalı şifre";
                RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer writer)
        {
            //Context context = new Context();
            //var writeruserinfo = context.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);

            var response = Request["g-recaptcha-response"];
            const string secret = "6LcPVl4bAAAAAPD3YgpmhpXvmX1APxK-jbmjv7Yi";
            var client = new WebClient();
            var reply = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}",
                secret, response));
            var captchaResponse = JsonConvert.DeserializeObject<captchaResponse>(reply);

            var writeruserinfo = writerLoginManager.GetWriter(writer.WriterMail, writer.WriterPassword);
            if (!captchaResponse.Succes)
            {
                TempData["Message"] = "Lütfen güvenliği doğrulayınız.";
                return View();
            }
            if (writeruserinfo != null )
            {
                FormsAuthentication.SetAuthCookie(writeruserinfo.WriterMail, false);
                Session["WriterMail"] = writeruserinfo.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                ViewData["ErrorMessage"] = "Kullanıcı adı veya Parola yanlış";
                return View("WriterLogin");
            }

        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }
    }

    public class captchaResponse
    {
        [JsonProperty("succes")]
        public bool Succes { get; set; }
        [JsonProperty("error-codes")]
        public List<string> ErrorCodes { get; set; }
    }
}