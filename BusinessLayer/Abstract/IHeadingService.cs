using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        Heading GetById(int id);
        List<Heading> GetList();
        void HeadingAddBL(Heading heading);
        void HeadingDelBl(Heading heading);
        void HeadingUpdBl(Heading heading);
    }
}
