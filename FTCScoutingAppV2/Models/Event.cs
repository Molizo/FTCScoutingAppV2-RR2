using System.ComponentModel.DataAnnotations;

namespace FTCScoutingAppV2.Models
{
    public class Event
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Event name")]
        public string eventName { get; set; }

        [Display(Name = "Event location")]
        public string eventLocation { get; set; }

        public string allowedUserIDs { get; set; }
    }
}