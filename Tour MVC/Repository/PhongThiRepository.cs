using System.Collections.Generic;
using System.Linq;
using Tour_MVC.Models;

namespace Tour_MVC.Repository
{
    public class PhongThiRepository
    {
        EnglishDbContext _context;

        public PhongThiRepository(EnglishDbContext context)
        {
            this._context = context;
        }
        public List<PhongThi> getAll()
        {
            return _context.PhongThis.ToList();
        }

       
    }
}
