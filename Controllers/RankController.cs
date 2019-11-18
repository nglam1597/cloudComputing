
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
    public class RankController : Controller
    {
        FootballTournamentEntities db = new FootballTournamentEntities();
        // GET: Rank
      
        public ActionResult Index()
        {
            var rankdb = db.Results.GroupBy(
                ac => new {
                    ac.MemberID
                }).Select(
                ac => new ResultModel() { 
                    Logo=db.Members.Where(x=>x.MemberID==ac.Key.MemberID).FirstOrDefault().Logo,
                    MemberID = ac.Key.MemberID,
                    Goal = ac.Sum(acs => acs.Goal),
                    Lost = ac.Sum(acs => acs.Lost),
                    Redcard = ac.Sum(acs => acs.Redcard),
                    Yellowcard = ac.Sum(acs => acs.Yellowcard),
                    Point = ac.Sum(acs => acs.Point),
                    win = ac.Count(acs => acs.Point == 3),
                    blost = ac.Count(acs => acs.Point == 0),
                    hoa=ac.Count(acs=>acs.Point==1),
                    Membername= db.Members.Where(x => x.MemberID == ac.Key.MemberID).FirstOrDefault().Membername
        }).ToList();
           
            return View(rankdb);
        }
    }
}