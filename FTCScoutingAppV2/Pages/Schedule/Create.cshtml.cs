using FTCScoutingAppV2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FTCScoutingAppV2.Pages.Schedule
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

        public IList<Team> AllTeams { get; set; }

        public string eventID { get; set; }

        [BindProperty]
        public MatchList MatchList { get; set; }

        public IList<Team> Teams { get; set; }

        #endregion Public Properties

        #region Public Methods

        public IActionResult OnGet()
        {
            AllTeams = _context.Team.ToList();
            eventID = HttpContext.Request.Query["eventID"];
            Teams = AllTeams.Where(team => team.eventID == eventID).ToList();

            IQueryable<Team> teamIQ = Teams.AsQueryable();
            teamIQ = teamIQ.OrderBy(t => t.teamID);
            Teams = teamIQ.AsNoTracking().ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            MatchList.eventID = HttpContext.Request.Query["eventID"];

            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.MatchList.Add(MatchList);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", new { eventID = HttpContext.Request.Query["eventID"], });
        }

        #endregion Public Methods
    }
}