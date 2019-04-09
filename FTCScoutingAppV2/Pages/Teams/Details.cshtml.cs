using FTCScoutingAppV2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FTCScoutingAppV2.Pages.Teams
{
    public class DetailsModel : PageModel
    {
        #region Private Fields

        private readonly FTCScoutingAppV2.Data.ApplicationDbContext _context;

        #endregion Private Fields

        #region Public Constructors

        public DetailsModel(FTCScoutingAppV2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion Public Constructors

        #region Public Properties

        public string eventID { get; set; }
        public Team Team { get; set; }

        #endregion Public Properties

        #region Public Methods

        public async Task<IActionResult> OnGetAsync(int? teamID)
        {
            if (teamID == null)
            {
                return NotFound();
            }

            Team = await _context.Team.FirstOrDefaultAsync(m => m.ID == teamID);

            if (Team == null)
            {
                return NotFound();
            }

            eventID = HttpContext.Request.Query["eventID"];

            return Page();
        }

        #endregion Public Methods
    }
}