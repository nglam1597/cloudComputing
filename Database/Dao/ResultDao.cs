using NamekWebPes.Database.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NamekWebPes.Database.Dao
{
    public class ResultDao
    {
        FootballTournamentEntities db = null;

        public ResultDao()
        {
            db = new FootballTournamentEntities();
        }
        //public List<ResultModel> ListMember()
        //{
        //    var model = (from a in db.Results
        //                 join b in db.Calendars on a.CalendarID equals b.CalendarID
        //                 select new ResultModel()
        //                 {
        //                     CalendarID = b.CalendarID,
        //                     NguoiChoi1 = b.NguoiChoi1,
        //                     NguoiChoi2 = b.NguoiChoi2
        //                 });
        //    return model.OrderBy(x => x.VongDau).Distinct().ToList();

        //}

        public List<Calendar> GetVongDau()
        {
            var sql = @"select distinct VongDau
                      from Calendar";
            var vongdau = db.Database.SqlQuery<Calendar>(sql).ToList();
            return vongdau;
        }

        public IEnumerable<Result> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Result> model = db.Results;


            return model.OrderByDescending(x => x.CalendarID).ToPagedList(page, pageSize);
        }


        public List<Result> ListCalendarID()
        {
            var sql = @"select * 
                      from Result";
            var calendarId = db.Database.SqlQuery<Result>(sql).ToList();
            return calendarId;
        }
    }
}