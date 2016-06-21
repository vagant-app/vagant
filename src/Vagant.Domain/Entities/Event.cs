using System;
using System.Collections.Generic;

namespace Vagant.Domain.Entities
{
    public class Event : BaseEntity
    {
        public string Title { get; set; }

        public string BriefDescription { get; set; }

        public string FullDescription { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public double Rate { get; set; }

        public int LocationId { get; set; }

        public int? LogoId { get; set; }

        public int? AudioId { get; set; }

        public string AuthorId { get; set; }

        public int? EventInstrumentId { get; set; }

        public virtual Location Location { get; set; }

        public virtual FileData Logo { get; set; }

        public virtual FileData Audio { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public virtual EventInstrument EventInstrument { get; set; }

        public virtual ICollection<EventRating> EventRatings { get; set; }
    }
}
