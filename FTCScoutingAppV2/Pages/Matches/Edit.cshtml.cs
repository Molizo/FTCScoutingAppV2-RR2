using FTCScoutingAppV2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FTCScoutingAppV2.Pages.Matches
{
    public class EditModel : PageModel
    {
        #region Private Fields

        private readonly FTCScoutingAppV2.Data.ApplicationDbContext _context;

        #endregion Private Fields

        #region Public Constructors

        public EditModel(FTCScoutingAppV2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion Public Constructors

        #region Public Properties

        [BindProperty]
        public Match Match { get; set; }

        #endregion Public Properties

        #region Public Methods

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

            return RedirectToPage("./Index", new { eventID = HttpContext.Request.Query["eventID"], teamID = HttpContext.Request.Query["teamID"], });
        }

        #endregion Public Methods

        #region Private Methods

        private bool MatchExists(int matchID)
        {
            return _context.Match.Any(e => e.teamID == matchID.ToString());
        }

        #endregion Private Methods
    }
}