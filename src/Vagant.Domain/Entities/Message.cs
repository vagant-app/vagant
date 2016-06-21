namespace Vagant.Domain.Entities
{
    public class Message : BaseEntity
    {
        public string AuthorId { get; set; }

        public string RecipientId { get; set; }

        public string Text { get; set; }

        public bool IsRead { get; set; }

        public ApplicationUser Author { get; set; }

        public ApplicationUser Recipient { get; set; }
    }
}
