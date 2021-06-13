using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi_UI.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        public ActionResult Index()
        {
            return View();
        }
    }
}