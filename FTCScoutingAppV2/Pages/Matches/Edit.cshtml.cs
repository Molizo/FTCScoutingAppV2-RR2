using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FTCScoutingAppV2.Data;
using FTCScoutingAppV2.Models;

namespace FTCScoutingAppV2.Pages.Matches
{
    public class EditModel : PageModel
    {
        private readonly FTCScoutingAppV2.Data.ApplicationDbContext _context;

        public EditModel(FTCScoutingAppV2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Match Match { get; set; }

        public async Task<IActionResult> OnGetAsync(int? matchID)
        {
            if (matchID == null)
            {
                return NotFound();
            }

            Match = await _context.Match.FirstOrDefaultAsync(m => m.ID == matchID);

            if (Match == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
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

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Match).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatchExists(Match.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Events/Index");
        }

        private bool MatchExists(int matchID)
        {
            return _context.Match.Any(e => e.teamID == matchID.ToString());
        }
    }
}
