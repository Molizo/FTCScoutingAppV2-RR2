using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FTCScoutingAppV2.Data;
using FTCScoutingAppV2.Models;

namespace FTCScoutingAppV2.Pages.Schedule
{
    public class IndexModel : PageModel
    {
        private readonly FTCScoutingAppV2.Data.ApplicationDbContext _context;

        public IndexModel(FTCScoutingAppV2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<MatchList> AllMatchList { get;set; }
        public IList<MatchList> MatchList { get; set; }
        public IList<Team> Teams { get;set;}

        public string eventID { get;set;}

        public async Task OnGetAsync()
        {
            AllMatchList = await _context.MatchList.ToListAsync();
            Teams = await _context.Team.ToListAsync();
            eventID = HttpContext.Request.Query["eventID"];
            MatchList = AllMatchList.Where(matchList => matchList.eventID == eventID).ToList();
            
        }
    }
}
