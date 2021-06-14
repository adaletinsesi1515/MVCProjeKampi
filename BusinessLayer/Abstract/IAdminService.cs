using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminService
    {
        Admin GetById(int id);
        List<Admin> GetList();
        void AdminAddBL(Admin admin);
        void AdminDelBl(Admin admin);
        void AdminUpdate(Admin admin);
    }
}
