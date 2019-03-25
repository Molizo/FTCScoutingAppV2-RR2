using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FTCScoutingAppV2.Data;
using FTCScoutingAppV2.Models;

namespace FTCScoutingAppV2.Pages.Matches
{
    public class IndexModel : PageModel
    {
        private readonly FTCScoutingAppV2.Data.ApplicationDbContext _context;

        public IndexModel(FTCScoutingAppV2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Match> AllMatches { get;set; }
        public IList<Team> Teams { get;set;}
        public IList<Match> Matches { get;set;}
        public string routingID { get;set;}

        public async Task OnGetAsync()
        {
            AllMatches = await _context.Match.ToListAsync();
            Matches = new List<Match>();
            routingID = HttpContext.Request.Query["id"];
            foreach(var match in AllMatches)
            {
                if(match.teamID == routingID)
                    Matches.Add(match);
            }
        }
    }
}
