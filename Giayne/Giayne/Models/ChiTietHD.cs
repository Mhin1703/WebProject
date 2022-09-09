using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Giayne.Models
{
    public class ChiTietHD
    {
        QLGIAYDataContext db = new QLGIAYDataContext();
        public string ctmasp { get; set; }
        public int ctsl { get; set; }
        public double ctgiaban { get; set; }
        public double ctthanhtien { get; set; }
        public virtual DonHang Donhang { get; set; }

      
    }
}