using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tour_MVC.Models;
using Tour_MVC.Repository;

namespace Tour_MVC.Controllers
{
    public class ChungNhanController : Controller
    {
        private readonly ThiSinhRepository _thiSinh;

        private ThiSinh thiSinh;
        public ChungNhanController(EnglishDbContext context)
        {
            _thiSinh = new ThiSinhRepository(context);
            thiSinh = new ThiSinh();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ChungNhan(int maphong,string cccd)
        {
            thiSinh = _thiSinh.findById(maphong,cccd);
            return View(thiSinh);
        }

        public virtual JsonResult ajaxChungNhanKetQua(string SBD)
        {
            thiSinh = _thiSinh.ChungNhanKetQua(SBD);
            return Json(thiSinh);
        }
    }
}
