using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FTCScoutingAppV2.Models
{
    public class Event
    {
        [Key]
        public int ID { get;set;}

        [Display(Name = "Event name")]
        public string eventName { get;set;}
        [Display(Name = "Event location")]
        public string eventLocation { get;set;}

        public List<Team> teams { get;set;}
        public string allowedUserIDs { get;set;}
    }
}
