using System.ComponentModel.DataAnnotations;

namespace FTCScoutingAppV2.Models
{
    public class Event
    {
        #region Public Properties

        public string allowedUserIDs { get; set; }

        [Display(Name = "Event location")]
        public string eventLocation { get; set; }

        [Display(Name = "Event name")]
        public string eventName { get; set; }

        [Key]
        public int ID { get; set; }

        #endregion Public Properties
    }
}