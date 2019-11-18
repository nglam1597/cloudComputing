
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NamekWebPes.Areas.Admin.Models;
using NamekWebPes.Database.Dao;
using NamekWebPes.Database.EF;
using Newtonsoft.Json;

namespace NamekWebPes.Areas.Admin.Controllers
{
    public class ResultController : BaseController
    {
        FootballTournamentEntities db = new FootballTournamentEntities();
        CalendarDao calendarDao = new CalendarDao();
        ResultDao resultDao = new ResultDao();
        // GET: Student
        public ActionResult Index()
        {

            return View();
        }

        public JsonResult GetResultList()
        {
            List<ResultViewModel> ResList = db.Results.Select(x => new ResultViewModel
            {
                ID = x.ID,
                CalendarID = x.CalendarID,
                Membername = x.Member.Membername,
                Goal = x.Goal,
                Lost = x.Lost,
                Point = x.Point,
                Yellowcard = x.Yellowcard,
                Redcard = x.Redcard

            }).ToList();
            return Json(ResList, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetResultByID(int ID)
        {
            Result model = db.Results.Where(x => x.ID == ID).SingleOrDefault();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            List<Member> MemList = db.Members.ToList();
            ViewBag.ListOfMember = new SelectList(MemList, "MemberID", "MemberName");

            List<Calendar> TranDauList = db.Calendars.ToList();
            List<CalendarViewModel> trandau = calendarDao.GetTranDau();
            ViewBag.TranDauList = new SelectList(TranDauList, "CalendarID", "TenTranDau");

            List<Calendar> VongDauList = db.Calendars.ToList();
            List<CalendarViewModel> vongdau = calendarDao.Get();
            SelectList vongdauList = new SelectList(vongdau, "VongDau", "VongDau");
            ViewBag.VongDauList = vongdauList;

            return View();
        }

        [HttpPost]
        public JsonResult SaveDataDatabase(List<ResultViewModel> lst)
        {

            try
            {
                if (lst.Count() > 0)
                {

                    var listCal = resultDao.ListCalendarID().Where(x => x.CalendarID == lst[0].CalendarID).ToList();
                    if (listCal.Count() > 0)
                    {
                        return Json(new
                        {
                            status = -1,
                            title = "Lỗi",
                            type = "error",
                            msg = "Trận đấu đã trùng"
                        });
                    }

                    foreach (var item in lst)
                    {
                        Result Stu = new Result();
                        Stu.CalendarID = lst[0].CalendarID;
                        Stu.MemberID = item.MemberID;
                        Stu.Goal = item.Goal;
                        Stu.Lost = item.Lost;
                        Stu.Point = item.Point;
                        Stu.Yellowcard = item.Yellowcard;
                        Stu.Redcard = item.Redcard;
                        db.Results.Add(Stu);
                        db.SaveChanges();
                    }
                }
                else
                {
                    return Json(new
                    {
                        status = -2,
                        title = "Lỗi",
                        type = "error",
                        msg = "Bạn chưa nhập dữ liệu"
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(new
            {
                status = 1,
                msg = "Thêm kết qua thành công"
            });
        }

        public JsonResult DeleteResultRecord(int ID)
        {
            bool result = false;
            Result Stu = db.Results.SingleOrDefault(x => x.ID == ID);
            if (Stu != null)
            {
                db.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //Member
        public JsonResult GetMember(int CalendarID)
        {
            db.Configuration.ProxyCreationEnabled = false;
            Calendar calendars = db.Calendars.Where(m => m.CalendarID == CalendarID).FirstOrDefault();

            List<ResultViewModel> resultModel = new List<ResultViewModel>();

            var foo1 = db.Members.Where(x => x.MemberID == calendars.NguoiChoi1).First();
            var foo2 = db.Members.Where(x => x.MemberID == calendars.NguoiChoi2).First();
            resultModel.Add(new ResultViewModel() { MemberID = foo1.MemberID, Membername = foo1.Membername });
            resultModel.Add(new ResultViewModel() { MemberID = foo2.MemberID, Membername = foo2.Membername });

            return Json(resultModel, JsonRequestBehavior.AllowGet);
        }

        //TranDau
        public JsonResult GetTranDau(int VongDau)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Calendar> Calendar = db.Calendars.Where(m => m.VongDau == VongDau).ToList();
            return Json(Calendar, JsonRequestBehavior.AllowGet);
        }

        
    }
}