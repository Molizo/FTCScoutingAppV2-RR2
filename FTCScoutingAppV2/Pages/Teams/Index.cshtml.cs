﻿using System;
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
        public string eventID { get;set; }
        public string eventName { get;set; }

        public string NameSort { get; set; }
        public string IDSort { get; set; }
        public string ExpPTSSort { get; set; }
        public string AvgPTSSort { get; set; }
        public string OPRSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public string eventRoutingID { get;set; }

        public async Task OnGetAsync(string eventID,string sortOrder)
        {
            AllTeams = await _context.Team.ToListAsync();
            Events = await _context.Event.ToListAsync();
            Matches = await _context.Match.ToListAsync();
            Teams = new List<Team>();
            AllowedUserIDs = String.Empty;

            eventRoutingID = eventID;

            foreach(var team in AllTeams)
            {
                if(team.eventID == eventID)
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

            try
            {
                var currentEvent = Events.Where(item => item.ID == Int32.Parse(eventID)).ToList();
                eventName = currentEvent[0].eventName;
            }
            catch
            {
                throw new Exception("Cannot retrieve teams for event with ID " + eventID);
            }

            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            IDSort = sortOrder == "id" ? "id_desc" : "id";
            ExpPTSSort = sortOrder == "exppts" ? "exppts_desc" : "exppts";
            AvgPTSSort = sortOrder == "avgpts" ? "avgpts_desc" : "avgpts";
            OPRSort = sortOrder == "opr" ? "opr_desc" : "opr";

            IQueryable<Team> teamIQ = Teams.AsQueryable();

            switch (sortOrder)
            {
                case "name_desc":
                    teamIQ = teamIQ.OrderByDescending(t => t.teamName);
                    break;
                case "id":
                    teamIQ = teamIQ.OrderBy(t => t.teamID);
                    break;
                case "id_desc":
                    teamIQ = teamIQ.OrderByDescending(t => t.teamID);
                    break;
                case "exppts":
                    teamIQ = teamIQ.OrderByDescending(t => t.ExpPTS);
                    break;
                case "exppts_desc":
                    teamIQ = teamIQ.OrderBy(t => t.ExpPTS);
                    break;
                case "avgpts":
                    teamIQ = teamIQ.OrderByDescending(t => t.AvgPTS);
                    break;
                case "avgpts_desc":
                    teamIQ = teamIQ.OrderBy(t => t.AvgPTS);
                    break;
                case "opr":
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
