using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NamekWebPes.Models
{
    public class ResultModel
    {
        
        
        public string Membername { get; set; }

       
        public int? CalenderID { get; set; }

        public int? MemberID { get; set; }

        public int? SoTran { get; set; }
        public int? Goal { get; set; }

        public int? Lost { get; set; }

        public int? Point { get; set; }

        public int? Yellowcard { get; set; }

        public int? Redcard { get; set; }

        public string Logo { get; set; }

        public int? win { get; set; }
        public int? blost { get; set; }
        public int? hoa { get; set; }



    }
}