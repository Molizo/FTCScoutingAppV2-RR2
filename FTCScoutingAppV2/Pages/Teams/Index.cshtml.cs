using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FTCScoutingAppV2.Data;
using FTCScoutingAppV2.Models;
using Microsoft.AspNetCore.Http;

namespace FTCScoutingAppV2.Pages.Teams
{
    public class IndexModel : PageModel
    {
        private readonly FTCScoutingAppV2.Data.ApplicationDbContext _context;

        public IndexModel(FTCScoutingAppV2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Event> Events { get; set; }
        public IList<Team> Teams { get;set; }
        public IList<Match> Matches { get; set; }
        public IList<Team> AllTeams { get;set; }
        public string AllowedUserIDs { get;set;}
        public string routingID { get;set; }
        public string eventName { get;set; }

        public string NameSort { get; set; }
        public string IDSort { get; set; }
        public string ExpPTSSort { get; set; }
        public string AvgPTSSort { get; set; }
        public string OPRSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            AllTeams = await _context.Team.ToListAsync();
            Events = await _context.Event.ToListAsync();
            Matches = await _context.Match.ToListAsync();
            Teams = new List<Team>();
            AllowedUserIDs = String.Empty;
            eventName = String.Empty;
            routingID = HttpContext.Request.Query["id"];
            foreach(var team in AllTeams)
            {
                if(team.eventID == routingID)
                {
                    Teams.Add(team);
                    UInt64 totalPoints=0,nrOfMatches=0;
                    foreach(var match in Matches)
                    {
                        if(match.teamID == team.ID.ToString())
                        {
                            totalPoints += match.points;
                            nrOfMatches++;
                        }
                    }
                    if(nrOfMatches != 0)
                        team.AvgPTS = totalPoints / nrOfMatches;
                }
            }
            foreach(var item in Events)
            {
                if(item.ID.ToString() == routingID)
                {
                    eventName = item.eventName;
                    AllowedUserIDs = item.allowedUserIDs;
                }
            }

            if(eventName == String.Empty)
                throw new Exception("Cannot retrieve teams for event with ID" + routingID);

            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            IDSort = sortOrder == "TeamID" ? "ID_desc" : "TeamID";
            ExpPTSSort = sortOrder == "ExpPTS" ? "exppts_desc" : "ExpPTS";
            AvgPTSSort = sortOrder == "AvgPTS" ? "avgpts_desc" : "AvgPTS";
            OPRSort = sortOrder == "OPR" ? "opr_desc" : "OPR";

            IQueryable<Team> teamIQ = Teams.AsQueryable();

            switch (sortOrder)
            {
                case "name_desc":
                    teamIQ = teamIQ.OrderByDescending(t => t.teamName);
                    break;
                case "TeamID":
                    teamIQ = teamIQ.OrderBy(t => t.teamID);
                    break;
                case "ID_desc":
                    teamIQ = teamIQ.OrderByDescending(t => t.teamID);
                    break;
                case "ExpPTS":
                    teamIQ = teamIQ.OrderByDescending(t => t.ExpPTS);
                    break;
                case "exppts_desc":
                    teamIQ = teamIQ.OrderBy(t => t.ExpPTS);
                    break;
                case "AvgPTS":
                    teamIQ = teamIQ.OrderByDescending(t => t.AvgPTS);
                    break;
                case "avgpts_desc":
                    teamIQ = teamIQ.OrderBy(t => t.AvgPTS);
                    break;
                case "OPR":
                    teamIQ = teamIQ.OrderByDescending(t => t.OPR);
                    break;
                case "opr_desc":
                    teamIQ = teamIQ.OrderBy(t => t.OPR);
                    break;
                default:
                    teamIQ = teamIQ.OrderBy(t => t.teamName);
                    break;
            }

            Teams = teamIQ.AsNoTracking().ToList();
        }
    }
}
