using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class LoginManager : ILoginService
    {
        IWriterLoginService _writerLoginService;
        IAdminService _adminService;

        public LoginManager(IWriterLoginService writerLoginService, IAdminService adminService)
        {
            _writerLoginService = writerLoginService;
            _adminService = adminService;
        }

        public Admin AdminLogin(Admin admin)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            string password = admin.AdminPassword;
            string result = Convert.ToBase64String(sha1.ComputeHash(Encoding.UTF8.GetBytes(password)));
            admin.AdminPassword = result;

            var adminInfo = _adminService.GetAdmin(admin.AdminUserName, result);
            return adminInfo;
        }

        public Writer WriterLogin(Writer writer)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            string password = writer.WriterPassword;
            string result = Convert.ToBase64String(sha1.ComputeHash(Encoding.UTF8.GetBytes(password)));
            writer.WriterPassword = result;

            var writerUserInfo = _writerLoginService.GetWriter(writer.WriterMail, result);
            return writerUserInfo;
        }
    }
}
