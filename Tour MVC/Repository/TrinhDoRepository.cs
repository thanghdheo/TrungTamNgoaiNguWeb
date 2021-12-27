using System.Collections.Generic;
using System.Linq;
using Tour_MVC.Models;

namespace Tour_MVC.Repository
{
    public class TrinhDoRepository 
    {
        EnglishDbContext _context;

        public TrinhDoRepository(EnglishDbContext context)
        {
            this._context = context;
        }
        public TrinhDo findById(string cccd)
        {
            throw new System.NotImplementedException();
        }

        public List<TrinhDo> getAll()
        {
            return _context.TrinhDos.ToList();
        }
    }
}
