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
    public class HeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());

        CategoryManager cm = new CategoryManager(new EfCategoryDal());

        WriterManager wm = new WriterManager(new EfWriterDal());
        // GET: Heading
        [Authorize]
        public ActionResult Index()
        {
            var headingvalues = hm.GetList();
            return View(headingvalues);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valuesCategory = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.vlcat = valuesCategory;

            List<SelectListItem> valuesWriter = (from y in wm.GetList()
                select new SelectListItem
                {
                    Text = y.WriterName+ " " +y.WriterSurname,
                    Value = y.WriterID.ToString()
                }).ToList();
            ViewBag.vlwrt = valuesWriter;


            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingAddBL(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditHeading(int Id)
        {
            List<SelectListItem> valuesCategory = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.vlcat = valuesCategory;

            var HeadingValues = hm.GetById(Id);
            return View(HeadingValues);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            p.HeadingStatus = true;
            hm.HeadingUpdBl(p);
            return RedirectToAction("Index");
        }
        
        public ActionResult DeleteHeading(int Id)
        {
            var HeadingValue = hm.GetById(Id);
            if (HeadingValue.HeadingStatus == true)
            {
                HeadingValue.HeadingStatus = false;
            }
            else
            {
                HeadingValue.HeadingStatus = true;
            }
            
             
            hm.HeadingDelBl(HeadingValue);
            return RedirectToAction("Index");          

        }

        public ActionResult HeadingReport()
        {
            var headingvalues = hm.GetList();
            return View(headingvalues);

        }

    }
}