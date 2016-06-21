using Agile.Web.Framework.ActionResults;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Vagant.Domain.Entities;
using Vagant.Domain.Services;

namespace Vagant.Web.Controllers
{
    public class FileDataController : Controller
    {
        #region Fields

        private readonly IFileDataService _fileDataService;

        #endregion

        #region Ctor

        public FileDataController(IFileDataService fileDataService)
        {
            _fileDataService = fileDataService;
        }

        #endregion

        #region Actions

        [HttpPost]
        public ActionResult Upload()
        {
            try
            {
                var file = GetFileFromStream();

                var fileData = new FileData
                {
                    Data = ReadToEnd(file.InputStream),
                    ContentType = file.ContentType
                };

                _fileDataService.Create(fileData);

                return new SuccessJsonResult(fileData.Id);
            }
            catch (Exception)
            {
                return new HttpBadRequestResult();
            }
        }

        [HttpGet]
        public ActionResult Download(int id)
        {
            var context = HttpContext;
            try
            {
                var fileData = _fileDataService.Get(id);

                if (fileData == null)
                {
                    return new HttpNotFoundResult();
                }

                return File(fileData.Data, fileData.ContentType);
            }
            catch (Exception)
            {
                //log error
                return new HttpBadRequestResult();
            }
        }

        #endregion

        #region Helper Methods

        private HttpPostedFileBase GetFileFromStream()
        {
            if (Request.Files.Count > 0)
            {
                return Request.Files[0];
            }

            return null;
        }

        private byte[] ReadToEnd(Stream stream)
        {
            long originalPosition = 0;

            if (stream.CanSeek)
            {
                originalPosition = stream.Position;
                stream.Position = 0;
            }

            try
            {
                var readBuffer = new byte[4096];

                int totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length)
                    {
                        int nextByte = stream.ReadByte();
                        if (nextByte != -1)
                        {
                            var temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                byte[] buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead)
                {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }
                return buffer;
            }
            finally
            {
                if (stream.CanSeek)
                {
                    stream.Position = originalPosition;
                }
            }
        }

        #endregion
    }
}