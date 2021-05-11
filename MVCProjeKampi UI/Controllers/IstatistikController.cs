using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi_UI.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik

        Context db = new Context();
        //CategoryManager cm = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            ViewBag.kategorisayisi = db.Categories.Where(x => x.CategoryStatus == true).Count();

            ViewBag.basliksay = db.Headings.Where(x => x.CategoryID == 12).Count();
            ViewBag.yazarsay = db.Writers.Where(x => x.WriterName.Contains("a")).Count();

            //En fazla başlığa sahip kategori adı

            var test = from p in db.Headings
                       group p by p.CategoryID into p
                       select new
                       {
                           BagliKategori = p.FirstOrDefault().Category.CategoryName,
                           Miktar = p.Count()
                       };     
          
            foreach (var item in test.OrderByDescending(x=>x.Miktar))
            {
                @ViewBag.TrendKategori = item.BagliKategori;
                break;
            }

            //Kategori tablosunda durumu true olan kategoriler ile false olan kategoriler arasındaki sayısal fark
            var truelar = db.Categories.Where(x => x.CategoryStatus == true).Count();
            var falseler = db.Categories.Where(x => x.CategoryStatus == false).Count();
            int sonuc = truelar - falseler;
            ViewBag.farknedir = sonuc;
            ViewBag.truedurum = truelar;
            ViewBag.falsedurum = falseler;


            return View();
        }
    }
}