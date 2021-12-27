using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Tour_MVC.Models;
using Tour_MVC.Repository;

namespace Tour_MVC.Controllers
{
    public class PhongThiController : Controller
    {
        private readonly ThiSinhRepository _thiSinh;

        private readonly KhoaThiRepository _khoaThi;

        private readonly PhongThiRepository _phongThi;

        private List<ThiSinh> thiSinhs;

        private List<KhoaThi> khoaThis;

        private List<PhongThi> phongThis;

        public PhongThiController(EnglishDbContext context)
        {
            _thiSinh = new ThiSinhRepository(context);
            _khoaThi = new KhoaThiRepository(context);
            _phongThi = new PhongThiRepository(context);
            thiSinhs = new List<ThiSinh>();
            khoaThis = new List<KhoaThi>();
            phongThis = new List<PhongThi>();
        }
        public IActionResult Index()
        {   
            if(thiSinhs.Count == 0)
            {
                thiSinhs = _thiSinh.DanhSachThiSinh();
            }
            if (khoaThis.Count == 0)
            {
                khoaThis = _khoaThi.getAll();
            }
            if (phongThis.Count == 0)
            {
                phongThis = _phongThi.getAll();
            }

            ViewBag.selectListKhoaThi = new SelectList(khoaThis, "MaKhoaThi", "TenKhoa");
            ViewBag.selectListPhongThi = new SelectList(phongThis, "MaPhong", "TenPhong");

            return View(thiSinhs);
        }

        public JsonResult ajaxSearchPhongThi(int maphong,int makhoa) 
        {
            thiSinhs = _thiSinh.searchPhong(maphong, makhoa);
            return Json(thiSinhs);
        }
    }
}
