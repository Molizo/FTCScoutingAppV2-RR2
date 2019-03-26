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

    public class Match
    {
        [Key]
        public int ID { get;set;}
        
        [Display(Name ="Match type")]
        public MatchTypes? matchType { get;set;}
        [Display(Name ="Match number")]
        public string matchNumber { get;set;}

        public string teamID { get;set;}
    }
}
