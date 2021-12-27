using System.Collections.Generic;
using System.Linq;
using Tour_MVC.Models;

namespace Tour_MVC.Repository
{
    public class NguoiDungRepository 
    {
        EnglishDbContext _context;

        public NguoiDungRepository(EnglishDbContext context)
        {
            this._context = context;
        }
        public bool Exist(string cccd)
        {
            NguoiDung nguoiDung = _context.NguoiDungs.Find(cccd);
                if(nguoiDung != null)
                return true;
            return false;
        }
        public List<NguoiDung> DanhSachTraCuu(string value)
        {
            var qr = from nd in _context.NguoiDungs
                     where nd.TenNguoiDung == value || nd.SoDienThoai == value
                     select nd;

            return qr.ToList();
        }

        public NguoiDung finddById(string cccd)
        {
            var qr = _context.NguoiDungs.Find(cccd);
            return qr;
        }
    }
}
