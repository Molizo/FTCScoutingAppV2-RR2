using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FTCScoutingAppV2.Models
{
    public enum MatchTypes
    {
        Qualification, Elimination
    }
    public enum Alliances
    {
        Red, Blue
    }
    public enum StartLocations
    {
        Crater, Depot, Any
    }

    public enum MatchStartLocations
    {
        Crater, Depot
    }

    public enum EndLocations
    {
        Latched, Fully, Partial, None
    }

}
