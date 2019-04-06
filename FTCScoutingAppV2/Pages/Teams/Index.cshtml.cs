using FTCScoutingAppV2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public IList<Team> Teams { get; set; }
        public IList<Team> AllTeams { get; set; }
        public string AllowedUserIDs { get; set; }
        public string routingID { get; set; }
        public string eventName { get; set; }

        public async Task OnGetAsync()
        {
            AllTeams = await _context.Team.ToListAsync();
            Events = await _context.Event.ToListAsync();
            Teams = new List<Team>();
            AllowedUserIDs = String.Empty;
            eventName = String.Empty;
            routingID = HttpContext.Request.Query["id"];
            foreach (var team in AllTeams)
            {
                if (team.eventID == routingID)
                    Teams.Add(team);
            }
            foreach (var item in Events)
            {
                if (item.ID.ToString() == routingID)
                {
                    eventName = item.eventName;
                    AllowedUserIDs = item.allowedUserIDs;
                }
            }

            if (eventName == String.Empty)
                throw new Exception("Cannot retrieve teams for event with ID" + routingID);
        }
    }
}