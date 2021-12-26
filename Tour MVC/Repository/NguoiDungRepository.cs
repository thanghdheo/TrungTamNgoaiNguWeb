using System.Collections.Generic;
using System.Linq;
using Tour_MVC.Interface;
using Tour_MVC.Models;

namespace Tour_MVC.Repository
{
    public class NguoiDungRepository : IRepository<NguoiDung>
    {
        EnglishDbContext _context;

        public NguoiDungRepository(EnglishDbContext context)
        {
            this._context = context;
        }
        public bool Add(NguoiDung entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Exist(string cccd)
        {
            NguoiDung nguoiDung = _context.NguoiDungs.Find(cccd);
                if(nguoiDung != null)
                return true;
            return false;
        }

        public NguoiDung findById(string cccd)
        {
            throw new System.NotImplementedException();
        }

        public List<NguoiDung> getAll()
        {
            throw new System.NotImplementedException();
        }

        public bool Update(NguoiDung entity)
        {
            throw new System.NotImplementedException();
        }

        public List<NguoiDung> DanhSachTraCuu(string value)
        {
            _context = new EnglishDbContext();
            var qr = from nd in _context.NguoiDungs
                     where nd.TenNguoiDung == value || nd.SoDienThoai == value
                     select nd;

            return qr.ToList();
        }
    }
}
