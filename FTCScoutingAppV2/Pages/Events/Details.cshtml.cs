using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FTCScoutingAppV2.Data;
using FTCScoutingAppV2.Models;

namespace FTCScoutingAppV2.Pages.Events
{
    public class DetailsModel : PageModel
    {
        private readonly FTCScoutingAppV2.Data.ApplicationDbContext _context;

        public DetailsModel(FTCScoutingAppV2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Event Event { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Event = await _context.Event.FirstOrDefaultAsync(m => m.ID == id);

            if (Event == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
