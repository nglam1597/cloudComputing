
using System;
using System.Collections.Generic;
using System.Linq;
using NamekWebPes.Models;
using System.Web;
using NamekWebPes.Database.EF;

namespace NamekWebPes.Dao
{
    public class MemberDao
    {

        FootballTournamentEntities db = null;
        public MemberDao()
        {
            db = new FootballTournamentEntities();
        }
        public List<int> GetMember()
        {
            List<int> numQuery2 =
                                    (from num in db.Members
                                     select num.MemberID).ToList();
            return numQuery2;
        }
       
 
        public IEnumerable<MemberModel> ListAll()
        {
            var q = (from a in db.Members
                     select new MemberModel
                     {
                         MemberID = a.MemberID,
                         Membername=a.Membername,
                         Club=a.Club,
                     });
            return q.ToList();

        }
    }
}