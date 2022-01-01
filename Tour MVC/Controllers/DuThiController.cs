using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Tour_MVC.Models;
using Tour_MVC.Repository;

namespace Tour_MVC
{
    public class DuThiController : Controller
    {
        private readonly KhoaThiRepository _khoaThi;

        private readonly TrinhDoRepository _trinhDo;

        private readonly DuThiRepository _duThi;

        private readonly NguoiDungRepository _nguoiDung;

        private List<KhoaThi> khoaThis;

        private List<TrinhDo> trinhDos;
        public DuThiController(EnglishDbContext context)
        {
            _khoaThi = new KhoaThiRepository(context);
            _trinhDo = new TrinhDoRepository(context);
            _duThi = new DuThiRepository(context);
            _nguoiDung = new NguoiDungRepository(context);
            khoaThis = new List<KhoaThi>();
            trinhDos = new List<TrinhDo>();
        }

        public IActionResult Index()
        {
            if(khoaThis.Count == 0)
            {
                khoaThis = _khoaThi.getAll().FindAll(s => s.ChotSo == false);
            }

            if(trinhDos.Count == 0)
            {
                trinhDos = _trinhDo.getAll();
            }
            ViewBag.selectListKhoaThi = new SelectList(khoaThis, "MaKhoaThi", "TenKhoa");
            ViewBag.selectListTrinhDo = new SelectList(trinhDos, "MaTrinhDo", "TenTrinhDo");
            return View();
        }

        [HttpPost]
        public IActionResult Index(DuThi duThi)
        {
            if (ModelState.IsValid)
            {
                if (_nguoiDung.Exist(duThi.Cccd))
                {
                    if (!_duThi.ExistDuThi(duThi.MaKhoaThi,duThi.Cccd))
                    {
                        if (_duThi.Add(duThi))
                        {
                            TempData["Message"] = "Đăng ký thành công";
                            return Redirect("DuThi/Index");
                        }
                        else
                        {
                            TempData["Message"] = "Đăng ký thất bại";
                            return Redirect("DuThi/Index");
                        }
                    }
                    else
                    {
                        TempData["Message"] = "Người dùng đã đăng ký khoá thi này rồi";
                        return Redirect("DuThi/Index");
                    }
                }
                else
                {
                    TempData["Message"] = "Không tìm thấy người dùng có cccd này";
                    return Redirect("DuThi/Index");
                }
            }
            return View();
        }
    }
}
