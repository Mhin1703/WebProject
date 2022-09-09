using Giayne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Giayne.Controllers
{
    public class NSXController : Controller
    {
        //
        // GET: /NSX/


        QLGIAYDataContext db = new QLGIAYDataContext();
        public ActionResult Index()
        {
            return View();
        }

        //Hien thi thanh NHASANXUAT
        public ActionResult NSXPartial()
        {
            var listNSX = db.NHASANXUATs.OrderBy(cd => cd.TENNSX).ToList();
            return View(listNSX);
        }

        //Hiển thị danh sách SANPHAM theo NHASANXUAT
        public ActionResult SPTheoNSX(int maNXB)
        {
            var listed = db.SANPHAMs.Where(emp => emp.MANSX == maNXB).ToList();
            if (listed.Count == 0)
            {
                return RedirectToAction("Index", "NSX");
            }
            return View(listed);
        }


	}
}