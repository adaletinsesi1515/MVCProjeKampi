using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi_UI.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel

        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

        public ActionResult WriterProfile()
        {
            return View();
        }

        public ActionResult MyHeading()
        {
            var values = headingManager.GetListByWriter();
            return View(values);
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valuesCategory = (from x in categoryManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.vlcat = valuesCategory;
            var HeadingValues = headingManager.GetById(id);
            return View(HeadingValues);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            p.HeadingStatus = true;
            headingManager.HeadingUpdBl(p);
            return RedirectToAction("MyHeading");
        }

        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> valuesCategory = (from x in categoryManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.vlcat = valuesCategory;            

            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading p)
        {
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.HeadingStatus = true;
            p.WriterID = 1;
            headingManager.HeadingAddBL(p);
            return RedirectToAction("MyHeading");
        }

        public ActionResult DeleteHeading(int Id)
        {
            var HeadingValue = headingManager.GetById(Id);
            if (HeadingValue.HeadingStatus == true)
            {
                HeadingValue.HeadingStatus = false;
            }
            else
            {
                HeadingValue.HeadingStatus = true;
            }


            headingManager.HeadingDelBl(HeadingValue);
            return RedirectToAction("MyHeading");

        }



    }
}