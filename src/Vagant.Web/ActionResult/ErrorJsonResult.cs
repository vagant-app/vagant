using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace Agile.Web.Framework.ActionResults
{
    public class ErrorJsonResult : JsonResult
    {
        #region Fields

        IEnumerable<string> _errorMessages;

        #endregion

        #region Ctors

        public ErrorJsonResult()
        {
        }

        public ErrorJsonResult(IEnumerable<string> errorMessages, object data = null)
            : base()
        {
            _errorMessages = errorMessages;
            Data = data;
        }

        #endregion

        #region Overridden methods

        public override void ExecuteResult(ControllerContext context)
        {
            HttpResponseBase response = context.HttpContext.Response;
            response.ContentType = !string.IsNullOrEmpty(ContentType) ? ContentType : "application/json";

            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }

            response.Write(JsonConvert.SerializeObject(new
            {
                isSuccess = false,
                errorMessages = _errorMessages ?? new string[0],
                data = Data
            }));
        }

        #endregion
    }
}