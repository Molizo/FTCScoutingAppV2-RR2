using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FTCScoutingAppV2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        #region Public Constructors

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        #endregion Public Constructors

        #region Public Properties

        public DbSet<FTCScoutingAppV2.Models.Event> Event { get; set; }
        public DbSet<FTCScoutingAppV2.Models.Match> Match { get; set; }
        public DbSet<FTCScoutingAppV2.Models.MatchList> MatchList { get; set; }
        public DbSet<FTCScoutingAppV2.Models.Team> Team { get; set; }

        #endregion Public Properties
    }
}