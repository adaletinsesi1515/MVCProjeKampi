using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }


        public void CategoryAddBL(Category category)
        {
            _categoryDal.Insert(category);
        }

        public void CategoryDelBl(Category category)
        {
            _categoryDal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDal.Update(category);

        }

        public Category GetById(int id)
        {
            return _categoryDal.Get(x => x.CategoryID == id);
        }

      
        public List<Category> GetList()
        {
            return _categoryDal.List(x=>x.CategoryStatus==true);
        }

        public void Sayi()
        {
            _categoryDal.List(p => p.CategoryStatus == true).Count();
        }












        //GenericRepository<Category> repo = new GenericRepository<Category>();

        //public List<Category> GetAllBL()
        //{
        //    return repo.List().Where(p=>p.CategoryStatus == true).ToList();
        //}
        //public List<Category> GetAllSartliBL()
        //{
        //    return repo.List();
        //}

        //public void CategoryAddBL (Category p)
        //{
        //    if (p.CategoryName == "" || p.CategoryName.Length<=3 || p.CategoryDescription == "" || p.CategoryName.Length >=51)
        //    {
        //        // hata mesajı döndürülecek
        //    }
        //    else
        //    {
        //        repo.Insert(p);
        //    }
        //}


    }
}
