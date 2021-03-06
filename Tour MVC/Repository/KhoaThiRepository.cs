using System.Collections.Generic;
using System.Linq;
using Tour_MVC.Models;

namespace Tour_MVC.Repository
{
    public class KhoaThiRepository 
    {
        EnglishDbContext _context;

        public KhoaThiRepository(EnglishDbContext context)
        {
            this._context = context;
        }
        public List<KhoaThi> getAll()
        {
            return _context.KhoaThis.ToList();
        }
    }
}
