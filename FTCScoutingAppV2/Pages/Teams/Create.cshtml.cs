using FTCScoutingAppV2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace FTCScoutingAppV2.Pages.Teams
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
        public Team Team { get; set; }

        #endregion Public Properties

        #region Public Methods

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Team.eventID = HttpContext.Request.Query["eventID"];

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
            expPTS += Team.goldMinerals * 5;
            expPTS += Team.silverMinerals * 5;
            expPTS += Team.depotMinerals * 2;
            Team.ExpPTS = expPTS;

            _context.Team.Add(Team);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", new { eventID = HttpContext.Request.Query["eventID"], });
        }

        #endregion Public Methods
    }
}