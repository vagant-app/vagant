using System.Collections.Generic;
using Vagant.Web.Models.Comment;
using Vagant.Web.Models.ContactInfo;
using Vagant.Web.Models.User;

namespace Vagant.Web.Models.Event
{
    public class EventDetailsViewModel : BaseEventViewModel
    {
        #region Properties

        public string AuthorName { get; set; }

        public string AuthorId { get; set; }

        public bool IsRatingEditable { get; set; }

        public double Rate { get; set; }

        public ReadOnlyContactInfoViewModel ContactInfo { get; set; }

        public IList<CommentViewModel> Comments { get; set; }

        public IList<UserViewModel> Visitors { get; set; }

        #endregion
    }
}