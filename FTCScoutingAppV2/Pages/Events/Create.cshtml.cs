using FTCScoutingAppV2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace FTCScoutingAppV2.Pages.Events
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
        public Event Event { get; set; }

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

            _context.Event.Add(Event);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        #endregion Public Methods
    }
}