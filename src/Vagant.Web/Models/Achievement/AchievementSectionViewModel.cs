using System.Collections.Generic;

namespace Vagant.Web.Models.Achievement
{
    public class AchievementSectionViewModel
    {
        #region Ctor

        public AchievementSectionViewModel()
        {
            Items = new List<AchievementViewModel>();
        }

        #endregion

        #region Properties

        public IList<AchievementViewModel> Items { get; set; }

        #endregion
    }
}