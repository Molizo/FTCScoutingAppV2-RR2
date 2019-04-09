using FTCScoutingAppV2.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FTCScoutingAppV2.Pages.Schedule
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

        public IList<MatchList> AllMatchList { get; set; }
        public string eventID { get; set; }
        public IList<MatchList> MatchList { get; set; }
        public IList<Team> Teams { get; set; }

        #endregion Public Properties

        #region Public Methods

        public async Task OnGetAsync()
        {
            AllMatchList = await _context.MatchList.ToListAsync();
            Teams = await _context.Team.ToListAsync();
            eventID = HttpContext.Request.Query["eventID"];
            MatchList = AllMatchList.Where(matchList => matchList.eventID == eventID).ToList();
        }

        #endregion Public Methods
    }
}