using NamekWebPes.Dao;
using NamekWebPes.Database.EF;
using NamekWebPes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NamekWebPes.Controllers
{
    public class HomeController : Controller
    {
        FootballTournamentEntities db = new FootballTournamentEntities();
        // GET: Home
        public ActionResult Index()
        { 
            var calenderModel = new List<CalendarModel>();
            var calenders = db.Calendars.ToList();

            foreach (var item in calenders)
            {
                
                var foo = new CalendarModel()
                {
                    CalendarID = item.CalendarID,
                    TenTranDau = item.TenTranDau,
                    VongDau=item.VongDau
                    
                    
                };
                foo.Membername1 = db.Members.Where(x => x.MemberID == item.NguoiChoi1).FirstOrDefault().Membername;
                foo.Membername2 = db.Members.Where(x => x.MemberID == item.NguoiChoi2).FirstOrDefault().Membername;
                foo.image1 = db.Members.Where(x => x.MemberID == item.NguoiChoi1).Select(x => x.Icon.ToString()).FirstOrDefault();
                foo.image2 = db.Members.Where(x => x.MemberID == item.NguoiChoi2).Select(x => x.Icon.ToString()).FirstOrDefault();
                foo.Goal = db.Results.Where(x => x.MemberID == item.NguoiChoi1).Where(x => x.CalendarID == item.CalendarID).Select(x => x.Goal).FirstOrDefault();
                foo.Lost = db.Results.Where(x => x.MemberID == item.NguoiChoi1).Where(x => x.CalendarID == item.CalendarID).Select(x => x.Lost).FirstOrDefault();

                calenderModel.Add(foo);
            }

            ViewBag.models = calenderModel;
            return View();
        }
        [HttpPost]
        public ActionResult GetTenByVongDau(int IDvongdau)
        {
            var calenderModel = new List<CalendarModel>();
            var lstCalender = db.Calendars.ToList().Where(m => m.VongDau == IDvongdau).ToList();

            foreach (var item in lstCalender)
            {
                var foo = new CalendarModel()
                {
                    CalendarID = item.CalendarID,
                    TenTranDau = item.TenTranDau,
                    VongDau = item.VongDau
                };
                foo.Membername1 = db.Members.Where(x => x.MemberID == item.NguoiChoi1).FirstOrDefault().Membername;
                foo.Membername2 = db.Members.Where(x => x.MemberID == item.NguoiChoi2).FirstOrDefault().Membername;
                foo.image1 = db.Members.Where(x => x.MemberID == item.NguoiChoi1).Select(x => x.Icon.ToString()).FirstOrDefault();
                foo.image2 = db.Members.Where(x => x.MemberID == item.NguoiChoi2).Select(x => x.Icon.ToString()).FirstOrDefault();
                foo.Goal = db.Results.Where(x => x.MemberID == item.NguoiChoi1).Where(x => x.CalendarID == item.CalendarID).Select(x => x.Goal).FirstOrDefault();
                foo.Lost = db.Results.Where(x => x.MemberID == item.NguoiChoi1).Where(x => x.CalendarID == item.CalendarID).Select(x => x.Lost).FirstOrDefault();
                calenderModel.Add(foo);
            }
            return PartialView("_DanhSachVongDau",calenderModel);
        }

        public PartialViewResult RankH()
        {
            var rankdb = db.Results.GroupBy(
                 ac => new {
                     ac.MemberID
                 }).Select(
                 ac => new ResultModel()
                 {
                     Logo = db.Members.Where(x => x.MemberID == ac.Key.MemberID).FirstOrDefault().Logo,
                     MemberID = ac.Key.MemberID,
                     SoTran=db.Results.Count(x=>x.MemberID==ac.Key.MemberID),
                     Goal = ac.Sum(acs => acs.Goal),
                     Lost = ac.Sum(acs => acs.Lost),
                     Redcard = ac.Sum(acs => acs.Redcard),
                     Yellowcard = ac.Sum(acs => acs.Yellowcard),
                     Point = ac.Sum(acs => acs.Point),
                     win = ac.Count(acs => acs.Point == 3),
                     blost = ac.Count(acs => acs.Point == 0),
                     hoa=ac.Count(acs=>acs.Point==1),
                     Membername = db.Members.Where(x => x.MemberID == ac.Key.MemberID).FirstOrDefault().Membername
                 }).ToList();
            return PartialView("_RankH", rankdb);
        }
    }
}