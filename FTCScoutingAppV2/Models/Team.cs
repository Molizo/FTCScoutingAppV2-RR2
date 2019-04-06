﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FTCScoutingAppV2.Models
{
    public enum StartLocations
    {
        Crater,Depot
    }

    public enum EndLocations
    {
        Latched,Fully,Partial,None
    }

    public class Team
    {
        [Key]
        public int ID { get;set;}

        [Display(Name = "Team ID",ShortName ="ID")]
        public string teamID { get;set;}
        [Display(Name = "Team name",ShortName ="Name")]
        public string teamName { get;set;}
        [Display(Name = "Team location",ShortName ="Location")]
        public string teamLocation { get;set;}
        
        [Display(Name ="Expected points",ShortName ="Exp PTS")]
        public int ExpPTS { get;set;}
        [Display(Name = "Average points", ShortName = "Avg PTS")]
        public int AvgPTS { get; set; }
        [Display(Name = "OPR points", ShortName = "OPR")]
        public int OPR { get; set; }

        [Display(Name ="Gold minerals",ShortName ="Gold")]
        public UInt64 goldMinerals { get;set;}
        [Display(Name = "Silver minerals", ShortName = "Silver")]
        public UInt64 silverMinerals { get; set; }
        [Display(Name = "Depot minerals", ShortName = "Depot")]
        public UInt64 depotMinerals { get; set; }
        [Display(Name = "Cycles minerals", ShortName = "Cycles")]
        public UInt64 cycles { get; set; }

        [Display(Name ="Preferred starting location",ShortName ="Str loc")]
        public StartLocations? startLocation { get;set;}

        [Display(Name ="Robot lands",ShortName ="LND")]
        public bool landing { get;set;}
        [Display(Name = "Does sampling",ShortName ="SMP")]
        public bool sampling { get; set; }
        [Display(Name = "2nd sampling",ShortName ="2nd SMP")]
        public bool doubleSampling { get; set; }
        [Display(Name = "Places team marker",ShortName ="MRK")]
        public bool teamMarker { get; set; }
        [Display(Name = "Robot parks",ShortName ="PRK")]
        public bool parking { get; set; }

        [Display(Name = "Ending location", ShortName = "End loc")]
        public EndLocations? endLocation { get; set; }

        [Display(Name ="Comments")]
        [DataType(DataType.MultilineText)]
        public string comments { get;set;}

        public string eventID { get;set;}
    }
}
