using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;

namespace MVCProjeKampi_UI.Controllers
{
    public class HeadingController : Controller
    {
        private HeadingManager hm = new HeadingManager(new EfHeadingDal());

        // GET: Heading
        public ActionResult Index()
        {
            var headingvalues = hm.GetList();
            return View(headingvalues);
        }
    }
}