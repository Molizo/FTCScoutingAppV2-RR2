using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FTCScoutingAppV2.Models
{
    public class Match
    {
        [Key]
        public int ID { get;set;}
        
        [Display(Name ="Match type")]
        public string matchType { get;set;}
        [Display(Name ="Match number")]
        public string matchNumber { get;set;}
    }
}
