using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Giayne.Models;
namespace Giayne.Controllers
{
    public class DangNhapController : Controller
    {
        //
        // GET: /DangNhap/
        QLGIAYDataContext db = new QLGIAYDataContext();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Login(KHACHHANG kh)
        {
            {
                if (ModelState.IsValid)
                {
                    var data = db.KHACHHANGs.Where(s => s.TAIKHOAN.Equals(kh.TAIKHOAN) && s.MATKHAU.Equals(kh.MATKHAU)).ToList();
                    if (data.Count() > 0)
                    {
                        Session["MAKH"] = data.FirstOrDefault().MAKH;
                        Session["TENKH"] = data.FirstOrDefault().TENKH;
                        Session["EMAIL"] = data.FirstOrDefault().EMAIL;
                        Session["DIACHI"] = data.FirstOrDefault().DIACHI;
                        Session["DT"] = data.FirstOrDefault().DT;
                        Session["NGAYSINH"] = data.FirstOrDefault().NGAYSINH;
                        Session["GIOITINH"] = data.FirstOrDefault().GIOITINH;
                        return RedirectToAction("SPpartial", "SanPham");
                    }
                    else
                    {
                        ViewBag.error = "Login failed";
                        return RedirectToAction("Login");
                    }
                }
                return View();

            }
        }


        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");

        }
       
        public ActionResult Index()
        {
            return View();
        }
	}
}