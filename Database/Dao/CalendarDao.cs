using NamekWebPes.Areas.Admin.Models;
using NamekWebPes.Database.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NamekWebPes.Database.Dao
{
    public class CalendarDao
    {
        FootballTournamentEntities db = null;

        public CalendarDao()
        {
            db = new FootballTournamentEntities();
        }

        public List<Calendar> listcalendar()
        {
            return db.Calendars.ToList();
        }

        public List<CalendarViewModel> Get()
        {
            var sql = @"select Distinct VongDau
                      from dbo.[Calendar]
                      ";
            var procvongdau = db.Database.SqlQuery<CalendarViewModel>(sql).Distinct().ToList();
            return procvongdau;
        }

        public List<CalendarViewModel> GetTranDau()
        {
            var sql = @"select TenTranDau
                      from dbo.[Calendar]
                      ";
            var proctrandau = db.Database.SqlQuery<CalendarViewModel>(sql).ToList();
            return proctrandau;
        }

    }
}