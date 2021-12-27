using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tour_MVC.Models;
using Tour_MVC.Repository;

namespace Tour_MVC.Controllers
{
    public class TraCuuController : Controller
    {
        private readonly NguoiDungRepository _nguoiDung;

        private readonly ThiSinhRepository _thiSinh;

        private List<NguoiDung> nguoiDungs;

        private List<ThiSinh> thiSinhs;
        public TraCuuController(EnglishDbContext context)
        {
            _nguoiDung = new NguoiDungRepository(context);
            _thiSinh = new ThiSinhRepository(context);
            nguoiDungs = new List<NguoiDung>();
            thiSinhs = new List<ThiSinh>();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TraCuu(string cccd)
        {
            if(thiSinhs.Count == 0)
            {
                thiSinhs = _thiSinh.DanhSachKetQua(cccd);
                ViewBag.name = thiSinhs[0].CccdNavigation.HoNguoiDung + " " + thiSinhs[0].CccdNavigation.TenNguoiDung;
            }
            return View(thiSinhs);
        }

        public IActionResult ThongTin(string cccd)
        {
            NguoiDung nguoiDung = _nguoiDung.finddById(cccd);
            return View(nguoiDung);
        }

        public IActionResult ajaxNguoiDung(string value)
        {
            nguoiDungs = _nguoiDung.DanhSachTraCuu(value);
            return Json(nguoiDungs);
        }

        
    }
}
