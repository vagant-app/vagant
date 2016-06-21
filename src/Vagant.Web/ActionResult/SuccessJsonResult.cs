using Newtonsoft.Json;
using System.Web;
using System.Web.Mvc;

namespace Agile.Web.Framework.ActionResults
{
    public class SuccessJsonResult : JsonResult
    {
        #region Ctors

        public SuccessJsonResult()
        {
        }

        public SuccessJsonResult(object data)
            : base()
        {
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
                isSuccess = true,
                data = Data
            }));
        }

        #endregion
    }
}