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
    public class DeleteModel : PageModel
    {
        private readonly FTCScoutingAppV2.Data.ApplicationDbContext _context;

        public DeleteModel(FTCScoutingAppV2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MatchList MatchList { get; set; }

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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? scheduledMatchID)
        {
            if (scheduledMatchID == null)
            {
                return NotFound();
            }

            MatchList = await _context.MatchList.FindAsync(scheduledMatchID);

            if (MatchList != null)
            {
                _context.MatchList.Remove(MatchList);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Events/Index");
        }
    }
}
