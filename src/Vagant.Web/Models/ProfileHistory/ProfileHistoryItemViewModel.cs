using System;

namespace Vagant.Web.Models.ProfileHistory
{
    public class ProfileHistoryItemViewModel
    {
        #region Properties

        public int EventId { get; set; }

        public string EventName { get; set; }

        public DateTime EventDate { get; set; }

        public double EventRate { get; set; }

        public bool CanClone { get; set; }

        #endregion
    }
}