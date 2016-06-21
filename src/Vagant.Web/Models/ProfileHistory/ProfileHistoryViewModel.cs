using System.Collections.Generic;

namespace Vagant.Web.Models.ProfileHistory
{
    public class ProfileHistoryViewModel
    {
        #region Ctor

        public ProfileHistoryViewModel()
        {
            Items = new List<ProfileHistoryItemViewModel>();
        }

        #endregion

        #region Properties

        public IList<ProfileHistoryItemViewModel> Items { get; set; }

        #endregion
    }
}