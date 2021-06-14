using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;

namespace MVCProjeKampi_UI.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery

        ImageFileManager Im = new ImageFileManager(new EfImageFileDal());

        [Authorize]
        public ActionResult Index()
        {
            var liste = Im.GetList();
            return View(liste);
        }
    }
}