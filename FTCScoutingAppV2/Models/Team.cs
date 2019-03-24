using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FTCScoutingAppV2.Models
{
    public class Team
    {
        [Key]
        public int ID { get;set;}

        [Display(Name = "Team ID")]
        public string teamID { get;set;}
        [Display(Name = "Team name")]
        public string teamName { get;set;}
        [Display(Name = "Team location")]
        public string teamLocation { get;set;}
        
        [Display(Name ="Comments")]
        [DataType(DataType.MultilineText)]
        public string comments { get;set;}

        public List<Match> matches { get;set;}
    }
}
