using Vagant.Web.Models.ContactInfo;

namespace Vagant.Web.Models.Profile
{
    public class EditProfileViewModel : BaseProfileViewModel
    {
        #region Ctor

        public EditProfileViewModel()
        {
            ContactInfo = new EditContactInfoViewModel();
        }

        #endregion

        #region Properties

        public EditContactInfoViewModel ContactInfo { get; set; }

        #endregion
    }
}