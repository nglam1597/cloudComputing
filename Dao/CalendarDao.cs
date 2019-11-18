
using NamekWebPes.Database.EF;
using NamekWebPes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NamekWebPes.Dao
{
    public class CalendarDao
    {
        FootballTournamentEntities db = null;
        public CalendarDao()
        {
            db = new FootballTournamentEntities();
        }
        public void AddNewCalender(Calendar entity)
        {
            db.Calendars.Add(entity);
            db.SaveChanges();
        }
       
        
        //public IEnumerable<CalendarModel> GetName1()
        //{
        //    var q = (from a in db.Members
        //             join b in db.Calendars on a.MemberID equals b.NguoiChoi1

        //             select new CalendarModel
        //             {
        //                 ID=b.ID,
        //                 NguoiChoi1=a.MemberID,
        //                 NguoiChoi2=a.MemberID,
        //                 Membername=a.Membername,
        //             }

        //             );
        //    return q.ToList();
        //}
        //public IEnumerable<CalendarModel> GetName2()
        //{
        //    var q = (from a in db.Members
        //             join b in db.Calendars on a.MemberID equals b.NguoiChoi2

        //             select new CalendarModel
        //             {
        //                 ID = b.ID,
        //                 NguoiChoi1 = a.MemberID,
        //                 NguoiChoi2 = a.MemberID,
        //                 Membername = a.Membername,
        //             }

        //             );
        //    return q.ToList();
        //}


        //public IEnumerable<CalendarModel> GetName3()
        //{
        //    var q = (from a in db.Calendars
        //             join b in db.Members on a.NguoiChoi1 equals b.MemberID
        //             join c in db.Members on a.NguoiChoi2 equals c.MemberID
        //             select new CalendarModel
        //             {
        //                 NguoiChoi1=b.MemberID,
        //                 NguoiChoi2=c.MemberID,
        //             }

        //             );
        //    return q.ToList();
        //}
      
        public IEnumerable<CalendarModel> ListAll()
        {
            var q = (from a in db.Calendars
                     select new CalendarModel
                     {
                         CalendarID = a.CalendarID,
                         TenTranDau = a.TenTranDau,
                         NguoiChoi1 = a.NguoiChoi1,
                         NguoiChoi2 = a.NguoiChoi2,
                     }

                     );
            return q.ToList();

        }
    }
}