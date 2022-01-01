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

        private List<ThiSinh> thiSinhs;
        public TraCuuController(EnglishDbContext context)
        {
            _nguoiDung = new NguoiDungRepository(context);
            _thiSinh = new ThiSinhRepository(context);
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
                if (_nguoiDung.Exist(cccd))
                {
                    if (_thiSinh.KiemTraThiChua(cccd))
                    {
                        thiSinhs = _thiSinh.DanhSachKetQua(cccd);
                        ViewBag.name = thiSinhs[0].CccdNavigation.HoNguoiDung + " " + thiSinhs[0].CccdNavigation.TenNguoiDung;
                    }
                    else
                    {
                        TempData["Message"] = "Người dùng này chưa thi";
                        return Redirect("Index");
                    }
                }
                else
                {
                    TempData["Message"] = "Không tìm thấy người dùng có cccd này";
                    return Redirect("Index");
                }
            }
            return View(thiSinhs);
        }

        public IActionResult ThongTin(string cccd)
        {
            if (_nguoiDung.Exist(cccd))
            {
                NguoiDung nguoiDung = _nguoiDung.finddById(cccd);
                return View(nguoiDung);
            }
            else
            {
                TempData["Message"] = "Không tìm thấy người dùng có cccd này";
                return Redirect("/PhongThi/Index");
            }
          
        }

        public IActionResult ajaxNguoiDung(string value)
        {
            var thiSinhs = _nguoiDung.DanhSachTraCuu(value);
            return Json(thiSinhs);
        }

        
    }
}
