﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public Message GetById(int id)
        {
            return _messageDal.Get(x=>x.MessageId == id);
        }

        public List<Message> GetListInbox(string mail)
        {
            //sağlıklı bir yöntem değil bu
            return _messageDal.List(x=>x.ReceiverMail == mail);
        }

        public List<Message> GetListInbox()
        {
            return _messageDal.List();
        }

        public List<Message> GetListSendbox(string mail)
        {
            return _messageDal.List(x => x.SenderMail == mail);
        }

        public List<Message> GetListSendbox()
        {
            return _messageDal.List();
        }

        public void MessageAddBL(Message message)
        {
            _messageDal.Insert(message);
        }

        public void MessageDelBl(Message message)
        {
            _messageDal.Delete(message);
        }

        public void MessageUpdBl(Message message)
        {
            _messageDal.Update(message);
        }
    }
}
