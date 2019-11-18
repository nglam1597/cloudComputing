
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
    public class CalendarController : Controller
    {
        // GET: Calendar
        FootballTournamentEntities db = new FootballTournamentEntities();
        public ActionResult Index()
        {
            var calenders = db.Calendars.ToList();
            var calenderModel = new List<CalendarModel>();
        
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
            return View(calenderModel);
        }









        //public JsonResult ID2(int membername)
        //{
        //    List<Calendar> calendars = db.Calendars.Where(m => m.NguoiChoi2 == membername).ToList();
        //    List<CalendarModel> calendarModels = new List<CalendarModel>();

        //    foreach (var item in calendars)
        //    {
        //        var foo = db.Members.Where(x => x.MemberID == item.NguoiChoi2).First();
        //        calendarModels.Add(new CalendarModel() { Membername = foo.Membername });

        //    }
        //    return Json(calendarModels, JsonRequestBehavior.AllowGet);
        //}
    }
}