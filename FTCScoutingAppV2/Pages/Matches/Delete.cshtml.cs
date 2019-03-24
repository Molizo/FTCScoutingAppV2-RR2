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
    public class DeleteModel : PageModel
    {
        private readonly FTCScoutingAppV2.Data.ApplicationDbContext _context;

        public DeleteModel(FTCScoutingAppV2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Match Match { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Match = await _context.Match.FirstOrDefaultAsync(m => m.ID == id);

            if (Match == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Match = await _context.Match.FindAsync(id);

            if (Match != null)
            {
                _context.Match.Remove(Match);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
