using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NamekWebPes.Areas.Admin.Models
{
    public class ResultViewModel
    {
        public int ID { get; set; }
        public int? CalendarID { get; set; }
        public int? MemberID { get; set; }
        public int? Goal { get; set; }
        public int? Lost { get; set; }
        public int? Point { get; set; }
        public int? Yellowcard { get; set; }
        public int? Redcard { get; set; }
        public int? NguoiChoi1 { get; set; }
        public int? NguoiChoi2 { get; set; }
        public string Membername { get; set; }
        public int VongDau { get; set; }
        public string TenTranDau { get; set; }
    }
}