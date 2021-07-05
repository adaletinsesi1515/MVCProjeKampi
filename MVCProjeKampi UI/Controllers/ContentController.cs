using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi_UI.Controllers
{
    [AllowAnonymous]
    public class ContentController : Controller
    {
        // GET: Content

        ContentManager cm = new ContentManager(new EfContentDal());

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContentByHeading(int Id)
        {
            var listele = cm.GetListById(Id);
            return View(listele);
        }


        [HttpGet]
        public ActionResult GetAllContent()
        {
            var values = cm.GetList();
            return View(values);
        }

        [HttpPost]
        public ActionResult GetAllContent(string p)
        {
            var values = cm.GetList(p);
            return View(values);
        }

    }
}