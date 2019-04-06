using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

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
    public class Match
    {
        [Key]
        public int ID { get;set;}
        
        [Display(Name ="Match type",ShortName ="Type")]
        public MatchTypes? matchType { get;set;}
        [Display(Name ="Match number",ShortName ="Nr")]
        public string matchNumber { get;set;}

        [Display(Name = "Alliance", ShortName = "Alc")]
        public Alliances? alliance { get; set; }
        [Display(Name = "Points earned", ShortName = "PTS")]
        public UInt64 points { get; set; }

        [Display(Name = "Starting location", ShortName = "Str loc")]
        public StartLocations? startLocation { get; set; }

        [Display(Name = "Robot lands", ShortName = "LND")]
        public bool landing { get; set; }
        [Display(Name = "Does sampling", ShortName = "SMP")]
        public bool sampling { get; set; }
        [Display(Name = "2nd sampling", ShortName = "2nd SMP")]
        public bool doubleSampling { get; set; }
        [Display(Name = "Places team marker", ShortName = "MRK")]
        public bool teamMarker { get; set; }
        [Display(Name = "Robot parks", ShortName = "PRK")]
        public bool parking { get; set; }

        [Display(Name = "Gold minerals", ShortName = "Gold")]
        public UInt64 goldMinerals { get; set; }
        [Display(Name = "Silver minerals", ShortName = "Silver")]
        public UInt64 silverMinerals { get; set; }
        [Display(Name = "Depot minerals", ShortName = "Depot")]
        public UInt64 depotMinerals { get; set; }
        [Display(Name = "Cycles", ShortName = "Cycles")]
        public UInt64 cycles { get; set; }

        [Display(Name = "Ending location", ShortName = "End loc")]
        public EndLocations? endLocation { get; set; }

        public string teamID { get;set;}
    }
}
