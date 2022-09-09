using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Giayne.Models;
using System.Data.Entity;
namespace Giayne.Controllers
{
    public class SanPhamController : Controller
    {
        QLGIAYDataContext db = new QLGIAYDataContext();
        // GET: SanPham
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SPpartial(string SearchString="")
        {
            if (SearchString != "")
            {
                var listsp = db.SANPHAMs.Include(s => s.TENSP).Where(x => x.TENSP.ToUpper().Contains(SearchString.ToUpper()));
                return View(listsp.ToList());
            }
            else
            {
                var listsp = db.SANPHAMs.OrderBy(s => s.TENSP).ToList();
                return View(listsp);
            }
        }
        public ActionResult xemChiTiet(int ms)
        {
            SANPHAM sach = db.SANPHAMs.Single(s => s.MASP == ms);
            if (sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }
    }
}