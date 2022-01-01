﻿using Microsoft.AspNetCore.Http;
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
            if (_thiSinh.Exist(maphong, cccd))
            {
                thiSinh = _thiSinh.findById(maphong, cccd);
                return View(thiSinh);
            }
            else
            {
                TempData["Message"] = "Không tìm thấy người dùng có cccd này";
                return Redirect("Index");
            }
           
        }

        public virtual JsonResult ajaxChungNhanKetQua(string SBD)
        {
            var thiSinh = _thiSinh.ChungNhanKetQua(SBD);
            return Json(thiSinh);
        }
    }
}
