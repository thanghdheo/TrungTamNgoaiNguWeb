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
        // GET: TraCuuController
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

        public IActionResult ajaxNguoiDung(string value)
        {
            nguoiDungs = _nguoiDung.DanhSachTraCuu(value);
            return Json(nguoiDungs);
        }

        // GET: TraCuuController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TraCuuController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TraCuuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TraCuuController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TraCuuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TraCuuController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TraCuuController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
