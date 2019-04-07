using FTCScoutingAppV2.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace FTCScoutingAppV2.Pages.Matches
{
    public class IndexModel : PageModel
    {
        private readonly FTCScoutingAppV2.Data.ApplicationDbContext _context;

        public IndexModel(FTCScoutingAppV2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Match> AllMatches { get; set; }
        public IList<Team> Teams { get; set; }
        public IList<Match> Matches { get; set; }

        public string eventRoutingID { get; set; }
        public string teamRoutingID { get; set; }

        public string teamNumber { get; set; }

        public string NrSort { get; set; }
        public string TypeSort { get; set; }
        public string PointsSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public async Task OnGetAsync(string eventID,string teamID,string sortOrder)
        {
            AllMatches = await _context.Match.ToListAsync();
            Teams = await _context.Team.ToListAsync();
            Matches = new List<Match>();

            eventRoutingID = eventID;
            teamRoutingID = teamID;

            Matches = AllMatches.Where(match => match.teamID == teamID).ToList();

            try
            {
                var currentTeam = Teams.Where(item => item.ID == Int32.Parse(teamID)).ToList();
                teamNumber = currentTeam[0].teamID;
            }
            catch
            {
                throw new Exception("Cannot retrieve matches for team with ID " + eventID);
            }

            NrSort = String.IsNullOrEmpty(sortOrder) ? "nr_desc" : "";
            TypeSort = sortOrder == "type" ? "type_desc" : "type";
            PointsSort = sortOrder == "points" ? "points_desc" : "points";

            IQueryable<Match> matchIQ = Matches.AsQueryable();

            switch (sortOrder)
            {
                case "nr_desc":
                    matchIQ = matchIQ.OrderByDescending(m => m.matchNumber);
                    break;
                case "type":
                    matchIQ = matchIQ.OrderBy(m => m.matchType);
                    break;
                case "type_desc":
                    matchIQ = matchIQ.OrderByDescending(m => m.matchType);
                    break;
                case "points":
                    matchIQ = matchIQ.OrderByDescending(m => m.points);
                    break;
                case "points_desc":
                    matchIQ = matchIQ.OrderBy(m => m.points);
                    break;
                default:
                    matchIQ = matchIQ.OrderBy(m => m.matchNumber);
                    break;
            }

            Matches = matchIQ.AsNoTracking().ToList();
        }
    }
}