using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FTCScoutingAppV2.Data;
using FTCScoutingAppV2.Models;

namespace FTCScoutingAppV2.Pages.Teams
{
    public class IndexModel : PageModel
    {
        private readonly FTCScoutingAppV2.Data.ApplicationDbContext _context;

        public IndexModel(FTCScoutingAppV2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Team> Team { get;set; }

        public async Task OnGetAsync()
        {
            Team = await _context.Team.ToListAsync();
        }
    }
}
