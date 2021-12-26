using System.Collections.Generic;
using System.Linq;
using Tour_MVC.Interface;
using Tour_MVC.Models;

namespace Tour_MVC.Repository
{
    public class TrinhDoRepository : IRepository<TrinhDo>
    {
        EnglishDbContext _context;

        public TrinhDoRepository(EnglishDbContext context)
        {
            this._context = context;
        }
        public bool Add(TrinhDo entity)
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

        public TrinhDo findById(string cccd)
        {
            throw new System.NotImplementedException();
        }

        public List<TrinhDo> getAll()
        {
            return _context.TrinhDos.ToList();
        }

        public bool Update(TrinhDo entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
