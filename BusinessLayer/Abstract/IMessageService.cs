using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        Message GetById(int id);
        List<Message> GetListInbox(string mail);
        List<Message> GetListSendbox(string mail);
        List<Message> GetListInbox();
        List<Message> GetListSendbox();
        void MessageAddBL(Message message);
        void MessageDelBl(Message message);
        void MessageUpdBl(Message message);
    }
}
