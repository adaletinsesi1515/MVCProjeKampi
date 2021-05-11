using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        Category GetById(int id);
        List<Category> GetList();
        void CategoryAddBL(Category category);                
        void CategoryDelBl(Category category);
        void CategoryUpdate(Category category);
        
    }
}
