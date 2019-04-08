using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FTCScoutingAppV2.Models
{
    public class MatchList
    {
        [Key]
        public int ID { get;set;}
        public string eventID { get;set;}

        [Display(Name ="Red team 1")]
        public int RedTeam1ID { get; set; }
        [Display(Name = "Red team 2")]
        public int RedTeam2ID { get; set; }
        [Display(Name = "Blue team 1")]
        public int BlueTeam1ID { get; set; }
        [Display(Name = "Blue team 2")]
        public int BlueTeam2ID { get; set; }

        [Display(Name = "Red alliance score")]
        public UInt64 RedScore { get; set; }
        [Display(Name = "Blue alliance score")]
        public UInt64 BlueScore { get; set; }
    }
}
