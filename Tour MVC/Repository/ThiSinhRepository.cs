using System.Collections.Generic;
using Tour_MVC.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Tour_MVC.Repository
{
    public class ThiSinhRepository 
    {
        EnglishDbContext _context;

        public ThiSinhRepository(EnglishDbContext context)
        {
            this._context = context;
        }
        public ThiSinh findById(int maphong,string cccd)
        {
            ThiSinh thiSinh = _context.ThiSinhs.Where(s => s.MaPhong == maphong && s.Cccd ==cccd)
                                                .Include(s => s.MaPhongNavigation).ThenInclude(s => s.MaKhoaThiNavigation)
                                                .Include(s => s.CccdNavigation).FirstOrDefault(); 
            return thiSinh;
        }

        public List<ThiSinh> DanhSachThiSinh()
        {
            return _context.ThiSinhs.Include(s => s.MaPhongNavigation).ThenInclude(ten => ten.MaKhoaThiNavigation)
                                    .Include(s => s.CccdNavigation).ToList();
        }

        public List<ThiSinh> searchPhong(int maphong, int makhoa)
        {
            var qr2 = from ts in _context.ThiSinhs
                      join q in _context.PhongThis on ts.MaPhong equals q.MaPhong
                      where ts.MaPhong == maphong && q.MaKhoaThi == makhoa
                      select new ThiSinh
                      {
                          Sbd = ts.Sbd,
                          Cccd = ts.Cccd,
                          CccdNavigation = ts.CccdNavigation,
                          MaPhongNavigation = ts.MaPhongNavigation
                      };

            return qr2.ToList();
        }

        public List<ThiSinh> DanhSachKetQua(string cccd)
        {
            var qr = from ts in _context.ThiSinhs
                     where ts.Cccd == cccd
                     select ts;
            return qr.Include(s => s.MaPhongNavigation)
                        .Include(s => s.CccdNavigation).ToList();
        }

        public List<ThiSinh> ChungNhanKetQua(string SBD)
        {
            var qr = from ts in _context.ThiSinhs
                     where ts.Sbd == SBD
                     select new ThiSinh
                     {
                         Sbd = SBD,
                         Cccd = ts.Cccd,
                         CccdNavigation = ts.CccdNavigation,
                         MaPhongNavigation = ts.MaPhongNavigation
                     };
            return qr.ToList();
        }

        public bool Exist (int maphong, string cccd)
        {
            ThiSinh thiSinh = _context.ThiSinhs.Find(maphong, cccd);
            if(thiSinh != null)
                return true;
            return false;
        }

        public bool KiemTraThiChua(string cccd)
        {
            ThiSinh thiSinh = _context.ThiSinhs.Where(s => s.Cccd == cccd).FirstOrDefault();
            if (thiSinh != null)
                return true;
            return false;
        }

    }
}
