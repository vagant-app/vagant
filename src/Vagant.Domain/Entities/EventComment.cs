﻿namespace Vagant.Domain.Entities
{
    public class EventComment : BaseEntity
    {
        public string Text { get; set; }

        public int EventId { get; set; }

        public string UserId { get; set; }

        public virtual Event Event { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
