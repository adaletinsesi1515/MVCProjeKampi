using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;

namespace MVCProjeKampi_UI.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel

        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        WriterValidator writerValidator = new WriterValidator();
        Context c = new Context();
        
        [HttpGet]
        public ActionResult WriterProfile()
        {
            int id;
            string p = (string)Session["WriterMail"];
            id = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var idvalue = writerManager.GetById(id);
            return View(idvalue);
        }

        [HttpPost]
        public ActionResult WriterProfile(Writer p)
        {
            ValidationResult result = writerValidator.Validate(p);
            if (result.IsValid)
            {
                //if (WriterImage.ContentLength > 0)
                //{
                //    var image = Path.GetFileName(WriterImage.FileName);
                //    var path = Path.Combine(Server.MapPath("~/Images"), image);
                //    WriterImage.SaveAs(path);
                //    p.WriterImage = "/Images/" + image;

                //}
                p.WriterStatus = true;
                writerManager.WriterUpdate(p);
                return RedirectToAction("AllHeading", "WriterPanel");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult MyHeading(string p)
        {
            
            p = (string)Session["WriterMail"];
            var idinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var values = headingManager.GetListByWriter(idinfo);
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
            string writermailinfo = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == writermailinfo).Select(y => y.WriterID).FirstOrDefault();

            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.HeadingStatus = true;
            p.WriterID = writeridinfo;
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


        public ActionResult AllHeading(int p=1)
        {

            var headings = headingManager.GetList().ToPagedList(p,4);
            return View(headings);
        }


    }
}