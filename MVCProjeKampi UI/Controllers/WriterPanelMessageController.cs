using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi_UI.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        // GET: WriterPanelMessage
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        public ActionResult Inbox(string p)
        {
            Context c = new Context();
            p = (string)Session["WriterMail"];
            var liste = c.Messages.Where(x => x.ReceiverMail == p).Select(y => y.ReceiverMail).FirstOrDefault();
            var messagelist = mm.GetListInbox(liste);
            return View(messagelist);
        }

        public ActionResult Sendbox(string p)
        {
            Context c = new Context();
            p = (string)Session["WriterMail"];
            var liste = c.Messages.Where(x => x.SenderMail == p).Select(y => y.SenderMail).FirstOrDefault();
            var messagelist = mm.GetListSendbox(liste);
            return View(messagelist);
        }

        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }

        public ActionResult GetMessageDetails(int id)
        {
            var messageValues = mm.GetById(id);
            return View(messageValues);
        }
        public ActionResult GetSendboxMessageDetails(int id)
        {
            var messageValues = mm.GetById(id);
            return View(messageValues);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message p, string p1)
        {
            MessageValidator messageValidator = new MessageValidator();
            ValidationResult result = messageValidator.Validate(p);
            if (result.IsValid)
            {
                p1 = (string)Session["WriterMail"];
                p.SenderMail = p1;
                p.MessageDate = DateTime.Now;
                mm.MessageAddBL(p);
                return RedirectToAction("Sendbox");
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