using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NamekWebPes.Models
{
    public class CalendarModel
    {
        public int CalendarID { get; set; }

        public int? VongDau { get; set; }

        public string TenTranDau { get; set; }

        public int? NguoiChoi1 { get; set; }

        public int? NguoiChoi2 { get; set; }
        public string image1 { get; set; }
        public string image2 { get; set; }

        public string Membername1 { get; set; }
        public string Membername2 { get; set; }

        public int? Goal { get; set; }

        public int? Lost { get; set; }

    }
}