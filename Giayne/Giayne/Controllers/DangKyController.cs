using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Giayne.Models;
namespace Giayne.Controllers
{
    public class DangKyController : Controller
    {
        //
        // GET: /DangKy/
        QLGIAYDataContext db = new QLGIAYDataContext();
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Register(KHACHHANG kh)
        {
            if (ModelState.IsValid)
            {
                var check = db.KHACHHANGs.FirstOrDefault(s => s.TAIKHOAN == kh.TAIKHOAN);
                if (check == null)
                {
                    db.KHACHHANGs.InsertOnSubmit(kh);

                    db.SubmitChanges();
                }
            }
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
	}
}