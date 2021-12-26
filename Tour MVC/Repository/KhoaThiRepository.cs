using System.Collections.Generic;
using System.Linq;
using Tour_MVC.Interface;
using Tour_MVC.Models;

namespace Tour_MVC.Repository
{
    public class KhoaThiRepository : IRepository<KhoaThi>
    {
        EnglishDbContext _context;

        public KhoaThiRepository(EnglishDbContext context)
        {
            this._context = context;
        }
        public bool Add(KhoaThi entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Exist(string cccd)
        {
            throw new System.NotImplementedException();
        }

        public KhoaThi findById(string cccd)
        {
            throw new System.NotImplementedException();
        }

        public List<KhoaThi> getAll()
        {
            return _context.KhoaThis.ToList();
        }

        public bool Update(KhoaThi entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
