using NamekWebPes.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NamekWebPes.Common;
using NamekWebPes.Database.EF;
using NamekWebPes.Models;

namespace NamekWebPes.Areas.Admin.Controllers
{
    public class CalendarController : BaseController
    {
        FootballTournamentEntities db = new FootballTournamentEntities();
        
        // GET: Admin/Calendar
        public ActionResult Index()
        {



            ViewBag.GiaiDauList = db.Tournaments.ToList();

            var membermodel = new List<MemberModel>();
            var members = db.Members.ToList();
            foreach(var item in members)
            {
                var foo = new MemberModel()
                {
                    MemberID = item.MemberID,
                    Membername=item.Membername,
                    
                };
                foo.TournamentName = db.Tournaments.Select(x => x.TournamentName).FirstOrDefault();
                membermodel.Add(foo);
            }

            return View(membermodel);
        }
      
        public PartialViewResult Calender()
        {   
            var calenders = db.Calendars.ToList();
            var calenderModel = new List<CalendarModel>();
            var cal = new CalendarDao();
            var calendar = new Calendar();

            foreach (var item in calenders)
            {
                var foo = new CalendarModel()
                {
                    CalendarID = item.CalendarID,
                    TenTranDau = item.TenTranDau,
                    VongDau = item.VongDau
                };
                foo.Membername1 = db.Members.Where(x => x.MemberID == item.NguoiChoi1).FirstOrDefault().Membername;
                foo.Membername2 = db.Members.Where(x => x.MemberID == item.NguoiChoi2).FirstOrDefault().Membername;
               
                calenderModel.Add(foo);
            }
            
            return PartialView("_ListCalender", calenderModel);


        }
        [HttpPost]
        public JsonResult RoundRobin(List<int> values)
        {
            var daocalender = new CalendarDao();
            var robin = new RoundRobin();
            robin.ListMatches(values);
            var model = daocalender.ListAll();
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}