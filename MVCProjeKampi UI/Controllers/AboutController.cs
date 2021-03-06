using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace MVCProjeKampi_UI.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public AboutManager abm = new AboutManager(new EfAboutDal());
        [Authorize]
        public ActionResult Index()
        {
            var values = abm.GetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        
        public ActionResult AddAbout(About p)
        {
            p.AboutStatus = true;
            abm.AboutAddBL(p);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }

        public ActionResult Aktif(int id)
        {
            var Value = abm.GetById(id);
            if (Value.AboutStatus== false)
            {
                Value.AboutStatus= true;
                
            }
            abm.AboutUpdate(Value);
            return RedirectToAction("Index");
        }

        public ActionResult Pasif(int id)
        {
            var Value = abm.GetById(id);
            if (Value.AboutStatus == true)
            {
                Value.AboutStatus = false;

            }
            abm.AboutUpdate(Value);
            return RedirectToAction("Index");
        }
    }
}