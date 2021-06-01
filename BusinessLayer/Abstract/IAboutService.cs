using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IAboutService
    {
        About GetById(int id);
        List<About> GetList();
        void AboutAddBL(About about);
        void AboutDelBl(About about);
        void AboutUpdate(About about);
    }
}
