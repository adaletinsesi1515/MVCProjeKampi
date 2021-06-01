using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public About GetById(int id)
        {
            return _aboutDal.Get(x=>x.AboutID == id);
        }

        public List<About> GetList()
        {
            return _aboutDal.List(x => x.AboutStatus== true);
        }

        public void AboutAddBL(About about)
        {
            _aboutDal.Insert(about);
        }

        public void AboutDelBl(About about)
        {
            _aboutDal.Update(about);
        }

        public void AboutUpdate(About about)
        {
            _aboutDal.Update(about);
        }
    }
}
