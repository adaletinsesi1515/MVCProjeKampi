﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public Heading GetById(int id)
        {
            return _headingDal.Get(x => x.HeadingID == id);
        }

        public List<Heading> GetList()
        {
            return _headingDal.List();
        }

        public List<Heading> GetListByWriter()
        {
            //.buradaki ID durumu değiştirilecek ileride
            return _headingDal.List(x => x.WriterID == 1);
        }

        public void HeadingAddBL(Heading heading)
        {
            _headingDal.Insert(heading);
        }

        public void HeadingDelBl(Heading heading)
        {
            _headingDal.Update(heading);
        }

        public void HeadingUpdBl(Heading heading)
        {
            _headingDal.Update(heading);
        }
    }
}
