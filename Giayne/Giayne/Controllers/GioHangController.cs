using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Giayne.Models;
using System.Linq;
namespace Giayne.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        QLGIAYDataContext db = new QLGIAYDataContext();
        public List<GioHang> layGioHang()
        {
            List<GioHang> lstGH = Session["GioHang"] as List<GioHang>;
            if(lstGH==null)
            {
                lstGH = new List<GioHang>();
                Session["GioHang"] = lstGH;
            }
            return lstGH;
        }
        public ActionResult ThemGioHang(int ms,string strURL)
        {
            List<GioHang> lstGH = layGioHang();
            GioHang sanPham = lstGH.Find(sp => sp.masp == ms);
            if(sanPham==null)
            {
                sanPham = new GioHang(ms);
                lstGH.Add(sanPham);
                return Redirect(strURL);
            }
            else
            {
                sanPham.sl++;
                return Redirect(strURL);
            }
        }
        private int TongSoLuong()
        {
            int tsl = 0;
            List<GioHang> lstGH = Session["GioHang"] as List<GioHang>;
            if(lstGH!=null)
            {
                tsl = lstGH.Sum(sp => sp.sl);
            }
            return tsl;
        }
        private double TongThanhTien()
        {
            double tt = 0;
            List<GioHang> lstGH = Session["GioHang"] as List<GioHang>;
            if (lstGH != null)
            {
                tt += lstGH.Sum(sp => sp.thanhtien);
            }
            return tt;
        }
        public ActionResult GioHang()
        {
            if(Session["GioHang"]==null)
            {
                return RedirectToAction("Index1", "Home");
            }
            List<GioHang> lstGH = layGioHang();
            ViewBag.TongSL = TongSoLuong();
            ViewBag.TongTT = TongThanhTien();
            return View(lstGH);
        }
        public ActionResult GioHangpartial()
        {
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongThanhTien = TongThanhTien();
            return PartialView();
        }
        public ActionResult xoaGH(int MaSP)
        {
            List<GioHang> lstGH = layGioHang();
            GioHang sp = lstGH.Single(s => s.masp == MaSP);
            if(sp!=null)
            {
                lstGH.RemoveAll(s => s.masp == MaSP);
                return RedirectToAction("GioHang", "GioHang");
            }    
            if(lstGH.Count==0)
            {
                return RedirectToAction("Index1", "Home");
            }
            return RedirectToAction("GioHang", "GioHang");
        }
        public ActionResult xoaGHAll()
        {
            List<GioHang> lstGH = layGioHang();
            lstGH.Clear();
            return RedirectToAction("Index1", "Home");
        }
        public ActionResult CapNhatGH(int MaSP,FormCollection f)
        {
            
            SANPHAM sp = db.SANPHAMs.SingleOrDefault(n => n.MASP == MaSP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> lstGH = layGioHang();
            GioHang gioHang = lstGH.SingleOrDefault(n => n.masp == MaSP);
            if (gioHang!=null)
            {
                gioHang.sl = int.Parse(f["txtSL"].ToString());
            }
            return RedirectToAction("GioHang", "GioHang");
        }
        public ActionResult SuaGioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> lstGioHang = layGioHang();
            return View(lstGioHang);

        }
        [HttpPost]
        public ActionResult DatHang()
        {
            //Thêm đơn hàng
            DONHANG ddh = new DONHANG();
            //Thêm chi tiết đơn hàng
            List<GioHang> gh = layGioHang();
            ddh.MAKH = int.Parse(Session["MAKH"].ToString());
            ddh.NGAYDAT = DateTime.Now;
            ddh.NGAYGIAO = DateTime.Now;
            db.DONHANGs.InsertOnSubmit(ddh);
            db.SubmitChanges();
            foreach (var item in gh)
            {
                CHITIETDONHANG ctdh = new CHITIETDONHANG();
                decimal thanhtien = item.sl * (decimal)item.giaban;
                ctdh.MADH = ddh.MADH;
                ctdh.MASP = item.masp;
                ctdh.SL = item.sl;
                ctdh.DONGIA = thanhtien;
                db.CHITIETDONHANGs.InsertOnSubmit(ctdh);
                db.SubmitChanges();

            }
            return View(gh);
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}