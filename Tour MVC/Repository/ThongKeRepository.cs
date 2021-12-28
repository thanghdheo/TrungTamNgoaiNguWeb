using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Tour_MVC.Models;

namespace Tour_MVC.Repository
{
    public class ThongKeRepository
    {
        EnglishDbContext _context;

        public ThongKeRepository(EnglishDbContext context)
        {
            this._context = context;
        }

        public List<KhoaThi> thongke(DateTime ngaybatdau, DateTime ngayketthuc)
        {
            var qr = from p in _context.KhoaThis
                     where p.NgayThi >= ngaybatdau && p.NgayThi <= ngayketthuc
                     select p;
            return qr.Include(s => s.PhongThis)
                    .ThenInclude( t => t.ThiSinhs).ToList();
        }
    }
}
