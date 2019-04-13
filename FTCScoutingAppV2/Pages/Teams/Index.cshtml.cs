using FTCScoutingAppV2.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FTCScoutingAppV2.Pages.Teams
{
    public class IndexModel : PageModel
    {
        #region Public Fields

        public static double EPS = 0.0000001d;
        public static int MAXN = 310;
        public IList<int> sum;
        public int[,] teams = new int[310, 310];

        #endregion Public Fields

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

        public string AllowedUserIDs { get; set; }
        public IList<MatchList> AllScheduledMatches { get; set; }
        public IList<Team> AllTeams { get; set; }
        public string AvgPTSSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public string eventID { get; set; }
        public string eventName { get; set; }
        public string eventRoutingID { get; set; }
        public IList<Event> Events { get; set; }
        public string ExpPTSSort { get; set; }
        public string IDSort { get; set; }
        public IList<Match> Matches { get; set; }
        public string NameSort { get; set; }
        public string OPRSort { get; set; }
        public List<MatchList> ScheduledMatches { get; set; }
        public IList<Team> Teams { get; set; }

        #endregion Public Properties

        #region Public Methods

        public void ComputeOPR()
        {
            System.Diagnostics.Debug.WriteLine("Computing OPR");
            int n = 0, m = 0;
            n = 2;
            m = 4;
            int i = 0, j = 0, k;

            int[,] v1 = new int[n + 10, m + 10];
            int[,] v2 = new int[m + 10, n + 10];
            int[,] v3 = new int[n + 10, n + 10];
            int[] v4 = new int[n + 10];
            double[,] A = new double[MAXN, MAXN];
            double[] X = new double[MAXN];

            for (i = 0; i < n; i++)
                for (j = 0; j < m; j++)
                {
                    v1[i, j] = teams[i, j];
                    v2[j, i] = v1[i, j];
                }

            for (i = 0; i < n; i++)
                for (j = 0; j < n; j++)
                {
                    v3[i, j] = 0;
                    for (k = 0; k <= m; k++)
                    {
                        v3[i, j] += v2[i, k] * v1[k, j];
                    }
                }

            for (i = 0; i < m; i++)
            {
                for (j = 0; j < m; j++)
                {
                    A[i + 1, j + 1] = v3[i, j];
                }

                for (k = 0; k <= m; k++)
                {
                    v4[i] += v2[i, k] * sum[k];
                }
                A[i + 1, m + 1] = v4[i];
            }

            char ch = '1';
            int N = m - 5;
            int M = m - 5;
            i = 1;
            j = 1;
            double aux;

            while (i <= N && j <= M)
            {
                for (k = i; k <= N; k++)
                    if (A[k, j] < -EPS || A[k, j] > EPS)
                        break;

                if (k == N + 1)
                {
                    j++;
                    continue;
                }

                if (k != i)
                    for (int l = 1; l <= M + 1; ++l)
                    {
                        aux = A[i, l];
                        A[i, l] = A[k, l];
                        A[k, l] = aux;
                    }

                for (int l = j + 1; l <= M + 1; ++l)
                    A[i, l] = A[i, l] / A[i, j];
                A[i, j] = 1;

                for (int u = i + 1; u <= N; ++u)
                {
                    for (int l = j + 1; l <= M + 1; ++l)
                        A[u, l] -= A[u, j] * A[i, l];
                    A[u, j] = 0;
                }

                i++;
                j++;
            }

            for (i = N; i > 0; --i)
                for (j = 1; j <= M + 1; ++j)
                    if (A[i, j] > EPS || A[i, j] < -EPS)
                    {
                        if (j == M + 1)
                        {
                            throw new Exception("Failed to compute OPR - Mathematical Error");
                        }

                        X[j] = A[i, M + 1];
                        for (k = j + 1; k <= M; ++k)
                            X[j] -= X[k] * A[i, k];

                        break;
                    }

            for (i = 1; i <= M; ++i)
            {
                System.Diagnostics.Debug.WriteLine(ch + " " + X[i]);
                ch++;
            }
            System.Diagnostics.Debug.WriteLine("Finished computing OPR");
        }

        public void ComputeSort(string sortOrder)
        {
            NameSort = sortOrder == "name" ? "name_desc" : "name";
            IDSort = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "id";
            ExpPTSSort = sortOrder == "exppts" ? "exppts_desc" : "exppts";
            AvgPTSSort = sortOrder == "avgpts" ? "avgpts_desc" : "avgpts";
            OPRSort = sortOrder == "opr" ? "opr_desc" : "opr";

            IQueryable<Team> teamIQ = Teams.AsQueryable();

            switch (sortOrder)
            {
                case "name":
                    teamIQ = teamIQ.OrderBy(t => t.teamName);
                    break;

                case "name_desc":
                    teamIQ = teamIQ.OrderByDescending(t => t.teamName);
                    break;

                case "id_desc":
                    teamIQ = teamIQ.OrderByDescending(t => t.teamID);
                    break;

                case "exppts":
                    teamIQ = teamIQ.OrderByDescending(t => t.ExpPTS);
                    break;

                case "exppts_desc":
                    teamIQ = teamIQ.OrderBy(t => t.ExpPTS);
                    break;

                case "avgpts":
                    teamIQ = teamIQ.OrderByDescending(t => t.AvgPTS);
                    break;

                case "avgpts_desc":
                    teamIQ = teamIQ.OrderBy(t => t.AvgPTS);
                    break;

                case "opr":
                    teamIQ = teamIQ.OrderByDescending(t => t.OPR);
                    break;

                case "opr_desc":
                    teamIQ = teamIQ.OrderBy(t => t.OPR);
                    break;

                default:
                    teamIQ = teamIQ.OrderBy(t => t.teamID);
                    break;
            }

            Teams = teamIQ.AsNoTracking().ToList();
        }

        public bool IsOPRComputeable()
        {
            IList<int> teamsMatchCounter = new List<int>();

            for (int team = 0; team < Teams.Count; team++)
                teamsMatchCounter.Add(0);
            for (int team = 0; team < Teams.Count; team++)
            {
                for (int match = 0; match < ScheduledMatches.Count; match++)
                {
                    if (Teams[team].ID == ScheduledMatches[match].RedTeam1ID || Teams[team].ID == ScheduledMatches[match].RedTeam2ID || Teams[team].ID == ScheduledMatches[match].BlueTeam1ID || Teams[team].ID == ScheduledMatches[match].BlueTeam2ID)
                        teamsMatchCounter[team]++;
                }
            }
            if (teamsMatchCounter.Contains(1) || teamsMatchCounter.Contains(0))
            {
                System.Diagnostics.Debug.WriteLine("OPR is not computable - Too few matches");
                return false;
            }
            else
                return true;
        }

        public async Task OnGetAsync(string eventID, string sortOrder)
        {
            AllTeams = await _context.Team.ToListAsync();
            Events = await _context.Event.ToListAsync();
            Matches = await _context.Match.ToListAsync();
            AllScheduledMatches = await _context.MatchList.ToListAsync();

            ScheduledMatches = AllScheduledMatches.Where(match => match.eventID == eventID).ToList();

            Teams = new List<Team>();
            AllowedUserIDs = String.Empty;

            eventRoutingID = eventID;

            foreach (var team in AllTeams)
            {
                if (team.eventID == eventID)
                {
                    Teams.Add(team);
                    UInt64 totalPoints = 0, nrOfMatches = 0;
                    foreach (var match in Matches)
                    {
                        if (match.teamID == team.ID.ToString())
                        {
                            totalPoints += match.points;
                            nrOfMatches++;
                        }
                    }
                    if (nrOfMatches != 0)
                        team.AvgPTS = totalPoints / nrOfMatches;
                }
            }

            try
            {
                var currentEvent = Events.Where(item => item.ID == Int32.Parse(eventID)).ToList();
                eventName = currentEvent[0].eventName;
            }
            catch
            {
                throw new Exception("Cannot retrieve teams for event with ID " + eventID);
            }

            if (IsOPRComputeable())
            {
                PrepareOPRDataset();
                //ComputeOPR();
            }
            ComputeSort(sortOrder);
        }

        public void PrepareOPRDataset()
        {
            // {{Team red 1, Team red 2, Blue team 1, Blue Team 2, RedScore, BlueScore},... - > i = Match nr &  j = Team nr {{0, 0, 0, 1, ...},...}
            System.Diagnostics.Debug.WriteLine("Preparing OPR dataset");
            sum = new List<int>();
            foreach (var match in ScheduledMatches)
            {
                sum.Add(Int32.Parse(match.RedScore.ToString()));
                sum.Add(Int32.Parse(match.BlueScore.ToString()));
            }
            System.Diagnostics.Debug.WriteLine("Added scores to sum");
            for (int teamNr = 0; teamNr < Teams.Count; teamNr++)
            {
                for (int matchNr = 0; matchNr < ScheduledMatches.Count * 2; matchNr += 2)
                {
                    if (Teams[teamNr].ID == ScheduledMatches[matchNr / 2].RedTeam1ID || Teams[teamNr].ID == ScheduledMatches[matchNr / 2].RedTeam2ID)
                        teams[matchNr, teamNr] = 1;
                    else if (Teams[teamNr].ID == ScheduledMatches[matchNr / 2].BlueTeam1ID || Teams[teamNr].ID == ScheduledMatches[matchNr / 2].BlueTeam2ID)
                        teams[matchNr + 1, teamNr] = 1;
                    else
                        teams[matchNr, teamNr] = 0;
                    System.Diagnostics.Debug.WriteLine(teams[matchNr, teamNr]);
                    System.Diagnostics.Debug.WriteLine(teams[matchNr + 1, teamNr]);
                }
            }
        }

        #endregion Public Methods
    }
}