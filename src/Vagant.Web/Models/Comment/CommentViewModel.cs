using Vagant.Web.Models.User;

namespace Vagant.Web.Models.Comment
{
    public class CommentViewModel
    {
        #region Properties

        public UserViewModel Author { get; set; }
        public string Text { get; set; }

        #endregion
    }
}