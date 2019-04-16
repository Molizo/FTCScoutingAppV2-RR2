using FTCScoutingAppV2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FTCScoutingAppV2.Pages.Matches
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

        public async Task<IActionResult> OnPostAsync(int? matchID)
        {
            if (matchID == null)
            {
                return NotFound();
            }

            Match = await _context.Match.FindAsync(matchID);

            if (Match != null)
            {
                _context.Match.Remove(Match);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", new { eventID = HttpContext.Request.Query["eventID"], teamID = HttpContext.Request.Query["teamID"], });
        }

        #endregion Public Methods
    }
}