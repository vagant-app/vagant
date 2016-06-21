using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Vagant.Web.Models.Location;

namespace Vagant.Web.Models.Event
{
    public class BaseEventViewModel : BaseViewModel
    {
        public BaseEventViewModel()
        {
            EventInstruments = new EventInstrumentsViewModel();
            Location = new LocationViewModel();
        }

        #region Properties

        public int EventId { get; set; }

        [Required]
        public string Title { get; set; }

        [DisplayName("Start Time")]
        [Required]
        public DateTime StartTime { get; set; }

        [DisplayName("End Time")]
        public DateTime? EndTime { get; set; }

        [DisplayName("Brief Description")]
        [Required]
        public string BriefDescription { get; set; }

        [DisplayName("Full Description")]
        [Required]
        public string FullDescription { get; set; }

        public int? LogoId { get; set; }

        public int? AudioId { get; set; }

        [DisplayName("Instruments")]
        public EventInstrumentsViewModel EventInstruments { get; set; }

        public LocationViewModel Location { get; set; }

        #endregion
    }
}