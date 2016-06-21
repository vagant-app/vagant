using System;

namespace Vagant.Domain.Models
{
    public class EventModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string BriefDescription { get; set; }

        public string FullDescription { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public double Rate { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int? LogoId { get; set; }

        public int? AudioId { get; set; }


        public string AuthorId { get; set; }

        public string AuthorName { get; set; }


        public bool IsGuitarUsed { get; set; }

        public bool IsViolinUsed { get; set; }

        public bool IsVocalApplicable { get; set; }

        public bool IsSaxophoneUsed { get; set; }
    }
}
