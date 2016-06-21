namespace Vagant.Web.Models.User
{
    public class UserViewModel
    {
        #region Properties

        public string UserId { get; set; }
        public string FullName { get; set; }

        public byte[] Avatar { get; set; }

        #endregion
    }
}