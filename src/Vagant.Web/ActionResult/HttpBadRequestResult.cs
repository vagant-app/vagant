using System.Net;
using System.Web.Mvc;

namespace Agile.Web.Framework.ActionResults
{
    public class HttpBadRequestResult : HttpStatusCodeResult
    {
        #region Ctor

        public HttpBadRequestResult()
            : base(HttpStatusCode.BadRequest)
        {
        }

        public HttpBadRequestResult(string message)
            : base(HttpStatusCode.BadRequest, message)
        {
        }

        #endregion
    }
}
