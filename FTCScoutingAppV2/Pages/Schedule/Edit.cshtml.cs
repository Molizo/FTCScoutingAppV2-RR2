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

namespace FTCScoutingAppV2.Pages.Schedule
{
    public class EditModel : PageModel
    {
        private readonly FTCScoutingAppV2.Data.ApplicationDbContext _context;

        public EditModel(FTCScoutingAppV2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MatchList MatchList { get; set; }

        public string eventID { get; set; }

        public async Task<IActionResult> OnGetAsync(int? scheduledMatchID)
        {
            if (scheduledMatchID == null)
            {
                return NotFound();
            }

            MatchList = await _context.MatchList.FirstOrDefaultAsync(m => m.ID == scheduledMatchID);

            if (MatchList == null)
            {
                return NotFound();
            }

            eventID = HttpContext.Request.Query["eventID"];

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MatchList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatchListExists(MatchList.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MatchListExists(int scheduledMatchID)
        {
            return _context.MatchList.Any(e => e.ID == scheduledMatchID);
        }
    }
}
