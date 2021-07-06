using MVCProjeKampi_UI.Sınıf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi_UI.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult CategoryChart()
        {
            return Json(Bloglist(), JsonRequestBehavior.AllowGet);
        }

        public List<CategoryChart> Bloglist()
        {
            List<CategoryChart> ct = new List<CategoryChart>();
            ct.Add(new CategoryChart()
            {
                CategoryName = "Yazılım",
                CategoryCount=8
            });
            ct.Add(new CategoryChart()
            {
                CategoryName = "Seyahat",
                CategoryCount = 4
            });
            ct.Add(new CategoryChart()
            {
                CategoryName = "Teknoloji",
                CategoryCount = 7
            });
            ct.Add(new CategoryChart()
            {
                CategoryName = "Spor",
                CategoryCount = 1
            });
            return ct;
        }

    }
}