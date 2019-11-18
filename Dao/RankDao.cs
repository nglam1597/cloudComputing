
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NamekWebPes.Database.EF;
using NamekWebPes.Models;

namespace NamekWebPes.Dao
{
    public class RankDao
    {
        FootballTournamentEntities db = null;
        public RankDao()
        {
            db = new FootballTournamentEntities();
        }
        public IEnumerable<ResultModel> ListAll()
        {
            var q = (from a in db.Members
                     join ai in db.Results
                     on a.MemberID equals ai.MemberID



                     select new ResultModel
                     {
                         
                         Membername = a.Membername,
                         Goal = ai.Goal,
                         Lost = ai.Lost,
                         Yellowcard = ai.Yellowcard,
                         Redcard = ai.Redcard,
                         Point = ai.Point,
                         Logo=a.Logo,
                     }


                     );
            return q.ToList();

        }
    }
}