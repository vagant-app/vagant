namespace Vagant.Web.Models.ContactInfo
{
    public class BaseContactInfoViewModel
    {
        #region Properties

        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string SkypeName { get; set; }
        public string VkProfileName { get; set; }
        public string FacebookProfileName { get; set; }
        public string TwitterProfileName { get; set; }
        public string InstagramProfileName { get; set; }

        public bool IsEditable { get; set; }

        #endregion
    }
}