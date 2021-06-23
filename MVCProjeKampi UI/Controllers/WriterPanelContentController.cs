using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityLayer.Concrete;

namespace MVCProjeKampi_UI.Controllers
{
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent
        ContentManager contentManager = new ContentManager(new EfContentDal());

        public ActionResult MyContent(string p)
        {
            Context c = new Context(); 
            p = (string)Session["WriterMail"];

            var writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var contentvalues = contentManager.GetListByWriter(writeridinfo);
            return View(contentvalues);

        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.deger = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content p)
        {
            Context c = new Context();
            string writermailinfo = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == writermailinfo).Select(y => y.WriterID).FirstOrDefault();

            p.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.ContentStatus= true;
            p.WriterID = writeridinfo;
            contentManager.ContentAddBL(p);
            return RedirectToAction("MyContent");
        }

    }
}