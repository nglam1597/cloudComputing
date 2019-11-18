using NamekWebPes.Dao;
using NamekWebPes.Database.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NamekWebPes.Common
{
    
    public class RoundRobin
    {
        FootballTournamentEntities db = new FootballTournamentEntities();
        public void ListMatches(List<int> ListTeam)
        {
            if (ListTeam.Count % 2 != 0)
            {
                ListTeam.Add(0);
                int numTeam = ListTeam.Count;
                int numDays = (numTeam - 1);
                int halfSize = numTeam / 2;

                List<int> teams = new List<int>();

                teams.AddRange(ListTeam.Skip(halfSize).Take(halfSize));
                teams.AddRange(ListTeam.Skip(1).Take(halfSize - 1).ToArray().Reverse());

                int teamsSize = teams.Count;
                var cal = new CalendarDao();
                var calendar = new Calendar();

                for (int day = 0; day < numDays; day++)
                {
                    int teamIdx = day % teamsSize;

                    //Console.WriteLine("{0} vs {1}", teams[teamIdx], ListTeam[0]);
                    calendar.VongDau = day + 1;
                    calendar.NguoiChoi1 = teams[teamIdx];
                   


                    calendar.NguoiChoi2 = ListTeam[0];
                    if(teams[teamIdx]!=0)
                    {
                        string n1 = db.Members.Where(x => x.MemberID == calendar.NguoiChoi1).FirstOrDefault().Membername.ToString();
                        string n2 = db.Members.Where(x => x.MemberID == calendar.NguoiChoi2).FirstOrDefault().Membername.ToString();
                        calendar.TenTranDau = $" {n1} vs {n2}";
                        cal.AddNewCalender(calendar);
                    }
                    


                    for (int idx = 1; idx < halfSize; idx++)
                    {
                        int firstTeam = (day + idx) % teamsSize;
                        int secondTeam = (day + teamsSize - idx) % teamsSize;
                        //Console.WriteLine("{0} vs {1}", teams[firstTeam], teams[secondTeam]);


                        calendar.NguoiChoi1 = teams[firstTeam];
                        calendar.NguoiChoi2 = teams[secondTeam];
                        if (teams[firstTeam] != 0 && teams[secondTeam] != 0)
                        {
                            string n1 = db.Members.Where(x => x.MemberID == calendar.NguoiChoi1).FirstOrDefault().Membername.ToString();
                            string n2 = db.Members.Where(x => x.MemberID == calendar.NguoiChoi2).FirstOrDefault().Membername.ToString();

                            calendar.TenTranDau = $" {n1} vs {n2}";


                            cal.AddNewCalender(calendar);
                        }  
                    }

                }
            }
            else
            {
                int numTeam = ListTeam.Count;
                int numDays = (numTeam - 1);
                int halfSize = numTeam / 2;

                List<int> teams = new List<int>();

                teams.AddRange(ListTeam.Skip(halfSize).Take(halfSize));
                teams.AddRange(ListTeam.Skip(1).Take(halfSize - 1).ToArray().Reverse());

                int teamsSize = teams.Count;
                var cal = new CalendarDao();
                var calendar = new Calendar();

                for (int day = 0; day < numDays; day++)
                {
                    int teamIdx = day % teamsSize;

                    //Console.WriteLine("{0} vs {1}", teams[teamIdx], ListTeam[0]);
                    calendar.VongDau = day + 1;
                    calendar.NguoiChoi1 = teams[teamIdx];
                    string n1 = db.Members.Where(x => x.MemberID == calendar.NguoiChoi1).FirstOrDefault().Membername.ToString();


                    calendar.NguoiChoi2 = ListTeam[0];
                    string n2 = db.Members.Where(x => x.MemberID == calendar.NguoiChoi2).FirstOrDefault().Membername.ToString();
                    calendar.TenTranDau = $" {n1} vs {n2}";
                    cal.AddNewCalender(calendar);


                    for (int idx = 1; idx < halfSize; idx++)
                    {
                        int firstTeam = (day + idx) % teamsSize;
                        int secondTeam = (day + teamsSize - idx) % teamsSize;
                        //Console.WriteLine("{0} vs {1}", teams[firstTeam], teams[secondTeam]);


                        calendar.NguoiChoi1 = teams[firstTeam];
                        calendar.NguoiChoi2 = teams[secondTeam];
                        n1 = db.Members.Where(x => x.MemberID == calendar.NguoiChoi1).FirstOrDefault().Membername;
                        n2 = db.Members.Where(x => x.MemberID == calendar.NguoiChoi2).FirstOrDefault().Membername;
                        calendar.TenTranDau = $" {n1} vs {n2}";


                        cal.AddNewCalender(calendar);
                    }

                }
            }
            

        }
    }
}