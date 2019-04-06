using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FTCScoutingAppV2.Data;
using FTCScoutingAppV2.Models;

namespace FTCScoutingAppV2.Pages.Matches
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
            return Page();
        }

        [BindProperty]
        public Match Match { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Match.teamID = HttpContext.Request.Query["id"];

            UInt64 points = 0;
            if (Match.landing == true)
                points += 30;
            if (Match.teamMarker == true)
                points += 15;
            if (Match.parking == true)
                points += 10;
            if (Match.sampling == true)
                points += 25;
            if (Match.doubleSampling == true)
                points += 25;
            if (Match.endLocation == EndLocations.Latched)
                points += 50;
            else if (Match.endLocation == EndLocations.Fully)
                points += 25;
            else if (Match.endLocation == EndLocations.Partial)
                points += 15;
            points += Match.goldMinerals * 5;
            points += Match.silverMinerals * 5;
            points += Match.depotMinerals * 2;
            Match.points = points;

            _context.Match.Add(Match);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Events/Index");
        }
    }
}