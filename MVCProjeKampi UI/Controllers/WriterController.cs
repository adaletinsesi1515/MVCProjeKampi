using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi_UI.Controllers
{
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterDal());

        WriterValidator writerValidator = new WriterValidator();


        // GET: Writer
        public ActionResult Index()
        {
            var listele = wm.GetList();
            return View(listele);
        }

        [HttpGet]
        public ActionResult WriterAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterAdd(Writer p, HttpPostedFileBase WriterImage)
        {
            ValidationResult result = writerValidator.Validate(p);
            if (result.IsValid)
            {
                if (WriterImage.ContentLength>0)
                {
                    var image = Path.GetFileName(WriterImage.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images"), image);
                    WriterImage.SaveAs(path);
                    p.WriterImage = "/Images/" + image;

                }
               
                wm.WriterAddBL(p);
                return RedirectToAction("Index");
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


        [HttpGet]
        public ActionResult EditWriter(int Id)
        {
            var result = wm.GetById(Id);
            return View(result);
        }

        [HttpPost]
        public ActionResult EditWriter(Writer p, HttpPostedFileBase WriterImage)
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

                wm.WriterUpdate(p);
                return RedirectToAction("Index");
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



    }
}