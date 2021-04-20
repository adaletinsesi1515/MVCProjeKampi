using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace DataAccessLayer.Concrete.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private Context db = new Context();
        DbSet<Category> _object;
        public List<Category> List()
        {
            return _object.ToList();
        }

        public void Insert(Category p)
        {
            _object.Add(p);
            db.SaveChanges();
        }

        public void Delete(Category p)
        {
            _object.Remove(p);
            db.SaveChanges();
        }

        public void Update(Category p)
        {
            db.SaveChanges();
        }
    }
}
