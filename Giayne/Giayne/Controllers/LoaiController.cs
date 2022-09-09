using Giayne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Giayne.Controllers
{
    public class LoaiController : Controller
    {


        QLGIAYDataContext db = new QLGIAYDataContext();
        //
        // GET: /Loai/
        public ActionResult Index()
        {
            return View();
        }


        //Hiển thị thanh Loại
        public ActionResult LOAIPartial()
        {
            var listLoai = db.LOAIs.OrderBy(cd => cd.TENLOAI).ToList();
            return View(listLoai);
        }

        //Hiển thị danh sách SANPHAM theo LOAI
        public ActionResult SPTheoLoai(int MaCD)
        {
            var listed = db.SANPHAMs.Where(emp => emp.MALOAI == MaCD).OrderBy(cd => cd.GIABAN).ToList();
            if (listed.Count == 0)
            {
                return RedirectToAction("Index", "Loai");
            }
            return View(listed);
        }
        


	}
}