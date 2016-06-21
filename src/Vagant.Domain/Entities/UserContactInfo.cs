namespace Vagant.Domain.Entities
{
    public class UserContactInfo : BaseEntity
    {
        public string SkypeName { get; set; }

        public string VkProfileName { get; set; }

        public string FacebookProfileName { get; set; }

        public string TwitterProfileName { get; set; }

        public string InstagramProfileName { get; set; }
    }
}
