using NamekWebPes.Database.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NamekWebPes.Dao
{
    public class TournamentDao
    {
        FootballTournamentEntities db = null;

        public TournamentDao()
        {
            db = new FootballTournamentEntities();
        }


        //public List<Tournament> GetGiaiDau()
        //{
        //    //var sql = @"select TournamentName from Tournaments";
        //    //var giaidau = db.Database.SqlQuery<Tournament>(sql).ToList();
        //    //return giaidau;
        //}
    }
}