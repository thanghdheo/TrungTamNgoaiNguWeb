using System.Collections.Generic;
using Tour_MVC.Interface;
using Tour_MVC.Models;

namespace Tour_MVC.Repository
{
    public class DuThiRepository : IRepository<DuThi>
    {
        EnglishDbContext _context;

        public DuThiRepository(EnglishDbContext context)
        {
            this._context = context;
        }

        public bool Add(DuThi entity)
        {
            _context.Add(entity);
            return Repository.SaveChanged(_context);
        }

        public bool Delete(int cccd)
        {
            throw new System.NotImplementedException();
        }

        public bool Exist(string cccd)
        {
            throw new System.NotImplementedException();
        }

        public bool ExistDuThi(int khoathi, string cccd)
        {
            DuThi duThi = _context.DuThis.Find(khoathi,cccd);
            if (duThi != null)
                return true;
            return false;
        }

        public DuThi findById(string cccd)
        {
            throw new System.NotImplementedException();
        }

        public List<DuThi> getAll()
        {
            throw new System.NotImplementedException();
        }

        public bool Update(DuThi entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
