using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace Vagant.Web.Controllers
{
    public class BaseController : Controller
    {
        protected string UserId
        {
            get
            {
                if (User == null || User.Identity == null)
                {
                    return null;
                }

                return User.Identity.GetUserId();
            }
        }
    }
}