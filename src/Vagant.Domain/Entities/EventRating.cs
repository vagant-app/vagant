namespace Vagant.Domain.Entities
{
    public class EventRating : BaseEntity
    {
        public string VoterId { get; set; }

        public int EventId { get; set; }

        public double RatingValue { get; set; }

        public virtual Event Event { get; set; }

        public virtual ApplicationUser Voter { get; set; }
    }
}
