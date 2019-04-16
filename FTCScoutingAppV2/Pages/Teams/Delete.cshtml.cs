using FTCScoutingAppV2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FTCScoutingAppV2.Pages.Teams
{
    public class DeleteModel : PageModel
    {
        #region Private Fields

        private readonly FTCScoutingAppV2.Data.ApplicationDbContext _context;

        #endregion Private Fields

        #region Public Constructors

        public DeleteModel(FTCScoutingAppV2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion Public Constructors

        #region Public Properties

        [BindProperty]
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? teamID)
        {
            if (teamID == null)
            {
                return NotFound();
            }

            Team = await _context.Team.FindAsync(teamID);

            if (Team != null)
            {
                _context.Team.Remove(Team);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", new { eventID = HttpContext.Request.Query["eventID"], });
        }

        #endregion Public Methods
    }
}