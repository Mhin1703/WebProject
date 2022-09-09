using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Giayne.Models
{
    public class GioHang
    {
        QLGIAYDataContext db = new QLGIAYDataContext();
        public int masp { get; set; }
        public string tensp { get; set; }

        public double giaban { get; set; }

        public int sl { get; set; }
        public string anh { get; set; }

        public double thanhtien

        {
            get { return sl * giaban; }
        }
        public GioHang(int ma)
        {
            masp = ma;
            SANPHAM sp = db.SANPHAMs.Single(s => s.MASP == masp);
            tensp = sp.TENSP;
            anh = sp.ANHBIA;
            giaban = double.Parse(sp.GIABAN.ToString());
            sl = 1;
        }

    }
}