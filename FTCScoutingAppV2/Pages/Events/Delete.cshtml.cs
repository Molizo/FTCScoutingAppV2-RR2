using FTCScoutingAppV2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FTCScoutingAppV2.Pages.Events
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
        public Event Event { get; set; }

        #endregion Public Properties

        #region Public Methods

        public async Task<IActionResult> OnGetAsync(int? eventID)
        {
            if (eventID == null)
            {
                return NotFound();
            }

            Event = await _context.Event.FirstOrDefaultAsync(m => m.ID == eventID);

            if (Event == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? eventID)
        {
            if (eventID == null)
            {
                return NotFound();
            }

            Event = await _context.Event.FindAsync(eventID);

            if (Event != null)
            {
                _context.Event.Remove(Event);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }

        #endregion Public Methods
    }
}