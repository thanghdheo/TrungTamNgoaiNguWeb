using System.Collections.Generic;
using Tour_MVC.Models;

namespace Tour_MVC.Repository
{
    public class DuThiRepository 
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
        public bool ExistDuThi(int khoathi, string cccd)
        {
            DuThi duThi = _context.DuThis.Find(khoathi,cccd);
            if (duThi != null)
                return true;
            return false;
        }
    }
}
