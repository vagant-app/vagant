using Microsoft.AspNet.Identity.EntityFramework;

namespace Vagant.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? AvatarId { get; set; }

        public int? ContactInfoId { get; set; }

        public virtual FileData Avatar { get; set; }

        public virtual UserContactInfo ContactInfo { get; set; }
    }
}
