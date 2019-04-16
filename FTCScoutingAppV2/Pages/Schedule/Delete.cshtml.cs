using FTCScoutingAppV2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FTCScoutingAppV2.Pages.Schedule
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

        public string eventID { get; set; }

        [BindProperty]
        public MatchList MatchList { get; set; }

        #endregion Public Properties

        #region Public Methods

        public async Task<IActionResult> OnGetAsync(int? scheduledMatchID)
        {
            eventID = HttpContext.Request.Query["eventID"];
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

            return RedirectToPage("./Index", new { eventID = HttpContext.Request.Query["eventID"], });
        }

        #endregion Public Methods
    }
}