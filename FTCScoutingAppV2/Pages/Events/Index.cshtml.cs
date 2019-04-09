using FTCScoutingAppV2.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FTCScoutingAppV2.Pages.Events
{
    public class IndexModel : PageModel
    {
        #region Private Fields

        private readonly FTCScoutingAppV2.Data.ApplicationDbContext _context;

        #endregion Private Fields

        #region Public Constructors

        public IndexModel(FTCScoutingAppV2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion Public Constructors

        #region Public Properties

        public IList<Event> Event { get; set; }

        #endregion Public Properties

        #region Public Methods

        public async Task OnGetAsync()
        {
            Event = await _context.Event.ToListAsync();
        }

        #endregion Public Methods
    }
}