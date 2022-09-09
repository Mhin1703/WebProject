using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Giayne.Models
{
    public class DonHang
    {
        QLGIAYDataContext db = new QLGIAYDataContext();
        public DonHang()
        {
            Chitietdonhang = new HashSet<CHITIETDONHANG>();
        }

        public string madh { get; set; }
        public string ngaydat { get; set; }
        public string ngaygiao { get; set; }
        public string dathanhtoan { get; set; }
        public string ttgiaohang { get; set; }
        public string makhdh { get; set; }
        public virtual ICollection<CHITIETDONHANG> Chitietdonhang { get; set; }
    }
}