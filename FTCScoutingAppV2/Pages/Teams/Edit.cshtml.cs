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

namespace FTCScoutingAppV2.Pages.Teams
{
    public class EditModel : PageModel
    {
        private readonly FTCScoutingAppV2.Data.ApplicationDbContext _context;

        public EditModel(FTCScoutingAppV2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Team Team { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Team = await _context.Team.FirstOrDefaultAsync(m => m.ID == id);

            if (Team == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Team).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamExists(Team.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            UInt64 expPTS = 0;
            if (Team.landing == true)
                expPTS += 30;
            if (Team.teamMarker == true)
                expPTS += 15;
            if (Team.parking == true)
                expPTS += 10;
            if (Team.sampling == true)
                expPTS += 25;
            if (Team.doubleSampling == true)
                expPTS += 25;
            if (Team.endLocation == EndLocations.Latched)
                expPTS += 50;
            else if (Team.endLocation == EndLocations.Fully)
                expPTS += 25;
            else if (Team.endLocation == EndLocations.Partial)
                expPTS += 15;
            expPTS+= Team.goldMinerals*5;
            expPTS += Team.silverMinerals * 5;
            expPTS += Team.depotMinerals * 2;
            Team.ExpPTS = expPTS;

            return RedirectToPage("/Events/Index");
        }

        private bool TeamExists(int id)
        {
            return _context.Team.Any(e => e.ID == id);
        }
    }
}
