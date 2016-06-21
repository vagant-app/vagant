namespace Vagant.Domain.Entities
{
    public class Visitor : BaseEntity
    {
        public string UserId { get; set; }

        public int EventId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual Event Event { get; set; }
    }
}
