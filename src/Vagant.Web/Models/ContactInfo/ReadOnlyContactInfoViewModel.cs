namespace Vagant.Web.Models.ContactInfo
{
    public class ReadOnlyContactInfoViewModel: BaseContactInfoViewModel
    {
        #region Ctor

        public ReadOnlyContactInfoViewModel()
        {
            IsEditable = false;
        }

        #endregion
    }
}