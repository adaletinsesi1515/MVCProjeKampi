using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void AdminAddBL(Admin admin)
        {
            _adminDal.Insert(admin);
        }

        public void AdminDelBl(Admin admin)
        {
            throw new NotImplementedException();
        }

        public Admin AdminRoles(string kullanici)
        {
            return _adminDal.List(x=>x.AdminUserName == kullanici).FirstOrDefault();
        }

        public void AdminUpdate(Admin admin)
        {
            throw new NotImplementedException();
        }

        public Admin GetById(string adi, string sifre)
        {
            return _adminDal.Get(x => x.AdminUserName == adi && x.AdminPassword == sifre);
        }

        public Admin GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Admin> GetList()
        {
            var liste = _adminDal.List();
            return liste;
        }

        void IAdminService.AdminRoles(string kullanici)
        {
            throw new NotImplementedException();
        }
    }
}
