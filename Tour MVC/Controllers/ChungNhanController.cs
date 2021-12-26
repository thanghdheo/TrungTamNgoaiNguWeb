using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        public IActionResult ajaxChungNhanKetQua(string SBD)
        {
            thiSinh = _thiSinh.ChungNhanKetQua(SBD);
            return Json(thiSinh);
        }

        // GET: ChungNhanController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ChungNhanController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChungNhanController/Create
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

        // GET: ChungNhanController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ChungNhanController/Edit/5
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

        // GET: ChungNhanController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ChungNhanController/Delete/5
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
