using NamekWebPes.Database.EF;
using NamekWebPes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NamekWebPes.Controllers
{
    public class LamController : Controller
    {
        // GET: Lam
        FootballTournamentEntities db = new FootballTournamentEntities();
        public ActionResult Index()
        {
            var members = @"select Club from Member group by Member.Club";
            var membermodel = db.Database.SqlQuery<MemberModel>(members).Distinct().ToList();

            return View(membermodel);
        }
      
        public ActionResult tenngchoi(string tendoibong)
        {
            var members = db.Members.Where(x => x.Club == tendoibong).Select(ac=>new MemberModel() {Membername=ac.Membername }).ToList();
           
            return PartialView("_tennguoichoi", members);

        }
    }
}