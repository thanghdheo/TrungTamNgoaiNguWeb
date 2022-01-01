using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tour_MVC.Models;
using Tour_MVC.Repository;

namespace Tour_MVC.Controllers
{
    public class DangKyController : Controller
    {
        private readonly NguoiDungRepository _nguoiDung;
        public DangKyController(EnglishDbContext context)
        {
            _nguoiDung = new NguoiDungRepository(context);
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(NguoiDung nguoiDung)
        {
            if (ModelState.IsValid)
            {
                if (!_nguoiDung.Exist(nguoiDung.Cccd))
                {
                    if (_nguoiDung.Register(nguoiDung))
                    {
                        TempData["Message"] = "Đăng ký thành công";
                        return Redirect("/DangKy/Index");
                    }
                    else
                    {
                        TempData["Message"] = "Đăng ký thất bại";
                        return Redirect("/DangKy/Index");
                    }
                }
                else
                {
                    TempData["Message"] = "Bạn đã đăng ký rồi";
                    return Redirect("/DangKy/Index");
                }
               
            }
            return View();
        }
    }
}
