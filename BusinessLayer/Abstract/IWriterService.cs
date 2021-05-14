using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        Writer GetById(int id);
        List<Writer> GetList();
        void WriterAddBL(Writer writer);
        void WriterDelBl(Writer writer);
        void WriterUpdate(Writer writer);
    }
}
