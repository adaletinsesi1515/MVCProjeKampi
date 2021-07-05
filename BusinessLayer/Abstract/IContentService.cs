using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        Content GetById(int id);
        List<Content> GetList();
        List<Content> GetList(string p);
        List<Content> GetListByWriter(int id);
        List<Content> GetListById(int Id);

        void ContentAddBL(Content content);
        void ContentDelBl(Content content);
        void ContentUpdate(Content content);

    }
}
