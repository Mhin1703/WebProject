using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Giayne.Models
{
    public class SPNSXMix
    {
        QLGIAYDataContext db = new QLGIAYDataContext();
        int masp{get; set;}
        string tensp { get; set; }
        int mansx { get; set; }
        string tennsx { get; set; }
        public SPNSXMix()
        {
            

        }

    }
}