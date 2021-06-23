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
    public class DefaultController : Controller
    {
        // GET: Default
        
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        private ContentManager contentManager = new ContentManager(new EfContentDal());
        public ActionResult Headings()
        {
            var listele = headingManager.GetList();
            return View(listele);
        }
        public PartialViewResult Index(int id=0)
        {
            var contentlist = contentManager.GetListById(id);
            return PartialView(contentlist);
        }

    }
}