using System.Collections.Generic;
using Vagant.Web.Models.ProfileHistory;

namespace Vagant.Web.Models.Profile
{
    public class BaseProfileViewModel : BaseViewModel
    {
        #region Ctor

        public BaseProfileViewModel()
        {
            HistoryItems = new List<ProfileHistoryItemViewModel>();
        }

        #endregion

        #region Properties

        public IList<ProfileHistoryItemViewModel> HistoryItems { get; set; }

        #endregion
    }
}