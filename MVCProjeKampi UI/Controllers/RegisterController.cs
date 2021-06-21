using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi_UI.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        AdminManager adminmanager = new AdminManager(new EfAdminDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());

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
            p.AdminRole = "B";
            adminmanager.AdminAddBL(p);
            return RedirectToAction("Index", "Login");            
        }

        [HttpGet]
        public ActionResult WriterRegister()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterRegister(Writer p)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            string password = p.WriterPassword;
            string result = Convert.ToBase64String(sha1.ComputeHash(Encoding.UTF8.GetBytes(password)));
            p.WriterPassword = result;
            p.WriterStatus = true;
            p.WriterImage = null;
            writerManager.WriterAddBL(p);
            return RedirectToAction("WriterLogin", "Login");
        }


    }
}