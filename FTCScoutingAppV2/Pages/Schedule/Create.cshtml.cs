using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FTCScoutingAppV2.Data;
using FTCScoutingAppV2.Models;

namespace FTCScoutingAppV2.Pages.Schedule
{
    public class CreateModel : PageModel
    {
        private readonly FTCScoutingAppV2.Data.ApplicationDbContext _context;

        public CreateModel(FTCScoutingAppV2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            AllTeams = _context.Team.ToList();
            eventID = HttpContext.Request.Query["eventID"];
            Teams = AllTeams.Where(team => team.eventID == eventID).ToList();

            return Page();
        }

        [BindProperty]
        public MatchList MatchList { get; set; }

        public IList<Team> AllTeams { get; set; }
        public IList<Team> Teams { get; set; }

        public string eventID { get;set;}

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            MatchList.eventID = eventID;

            _context.MatchList.Add(MatchList);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Events/Index");
        }
    }
}