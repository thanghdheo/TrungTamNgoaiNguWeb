using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using Tour_MVC.Models;
using Tour_MVC.Repository;

namespace Tour_MVC.Controllers
{
    public class ThongKeController : Controller
    {
        private readonly ThongKeRepository _thongKe;

        private readonly TrinhDoRepository _trinhDo;

        private List<TrinhDo> trinhDos;
        public ThongKeController(EnglishDbContext context)
        {
            _thongKe = new ThongKeRepository(context);
            _trinhDo = new TrinhDoRepository(context);
            trinhDos = new List<TrinhDo>();
        }
        public ActionResult Index()
        {
            if (trinhDos.Count == 0)
            {
                trinhDos = _trinhDo.getAll();
            }
            ViewBag.selectListTrinhDo = new SelectList(trinhDos, "MaTrinhDo", "TenTrinhDo");
            return View();
        }

        public JsonResult ajaxThongKe(DateTime ngaybatdau, DateTime ngayketthuc)
        {
            List<KhoaThi> khoaThis = _thongKe.thongke(ngaybatdau,ngayketthuc);

            int tongptA2 = 0,tongptB1 = 0, tongtsA2 = 0, tongtsB1 = 0;

            foreach(KhoaThi k in khoaThis)
            {
                List<PhongThi> phongThis = k.PhongThis.ToList();
                List<PhongThi> phongthiA2 = phongThis.FindAll(s => s.MaTrinhDo == 2);
                List<PhongThi> phongthiB1 = phongThis.FindAll(s => s.MaTrinhDo == 1);
                tongptA2 += phongthiA2.Count;
                tongptB1 += phongthiB1.Count;

                foreach (PhongThi p in phongthiA2)
                {
                    tongtsA2 += p.ThiSinhs.Count;
                }

                foreach (PhongThi p in phongthiB1)
                {
                    tongtsB1 += p.ThiSinhs.Count;
                }

            }

            ThongKe thongKe = new ThongKe
            {
                slKhoaThi = khoaThis.Count,
                slPhongThiA2 = tongptA2,
                slPhongThiB1 = tongptB1,
                slThiSinhB1 = tongtsB1,
                slThiSinhA2 = tongtsA2,
            };


            return Json(thongKe);
        }
    }
}
