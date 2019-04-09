using FTCScoutingAppV2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace FTCScoutingAppV2.Pages.Matches
{
    public class CreateModel : PageModel
    {
        #region Private Fields

        private readonly FTCScoutingAppV2.Data.ApplicationDbContext _context;

        #endregion Private Fields

        #region Public Constructors

        public CreateModel(FTCScoutingAppV2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion Public Constructors

        #region Public Properties

        [BindProperty]
        public Match Match { get; set; }

        #endregion Public Properties

        #region Public Methods

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string eventID, string teamID)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Match.teamID = HttpContext.Request.Query["teamID"];

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

        #endregion Public Methods
    }
}