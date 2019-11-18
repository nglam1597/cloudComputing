using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NamekWebPes.Areas.Admin.Models
{
    public class CalendarViewModel
    {
        public int CalendarID { get; set; }
        public int VongDau { get; set; }
        public string TenTranDau { get; set; }
        public int NguoiChoi1 { get; set; }
        public int NguoiChoi2 { get; set; }
        public string Membername { get; set; }
    }
}