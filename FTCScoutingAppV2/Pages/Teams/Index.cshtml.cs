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

        public IList<Team> Teams { get;set; }
        public IList<Team> AllTeams { get;set;}
        public string routingID { get;set;}

        public async Task OnGetAsync()
        {
            AllTeams = await _context.Team.ToListAsync();
            Teams = new List<Team>();
            routingID = HttpContext.Request.Query["id"];
            foreach(var team in AllTeams)
            {
                if(team.eventID == routingID)
                    Teams.Add(team);
            }
        }
    }
}
