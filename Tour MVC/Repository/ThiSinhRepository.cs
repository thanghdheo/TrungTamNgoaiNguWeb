using System.Collections.Generic;
using Tour_MVC.Interface;
using Tour_MVC.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Tour_MVC.Repository
{
    public class ThiSinhRepository : IRepository<ThiSinh>
    {
        EnglishDbContext _context;

        public ThiSinhRepository(EnglishDbContext context)
        {
            this._context = context;
        }
        public bool Add(ThiSinh entity)
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

        public ThiSinh findById(string cccd)
        {
            ThiSinh thiSinh = _context.ThiSinhs.Find(cccd);
            return thiSinh;
        }

        public List<ThiSinh> DanhSachKetQua(string cccd)
        {
            var qr = from ts in _context.ThiSinhs
                     where ts.Cccd == cccd
                     select ts;
            return qr.Include(s => s.MaPhongNavigation)
                        .Include(s => s.CccdNavigation).ToList();
        }

        public ThiSinh ChungNhanKetQua(string SBD)
        {
            var qr = from ts in _context.ThiSinhs
                     where ts.Sbd == SBD
                     select ts;
            return qr.Include(s => s.CccdNavigation).First();
        }

        public List<ThiSinh> getAll()
        {
            throw new System.NotImplementedException();
        }

        public bool Update(ThiSinh entity)
        {
            throw new System.NotImplementedException();
        }

        
    }
}
