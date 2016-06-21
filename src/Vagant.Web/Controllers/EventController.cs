using Agile.Web.Framework.ActionResults;
using Microsoft.AspNet.Identity;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vagant.Domain.Entities;
using Vagant.Domain.Models;
using Vagant.Domain.Services;
using Vagant.Web.Extensions;
using Vagant.Web.Models.Event;
using Vagant.Web.Models.Location;

namespace Vagant.Web.Controllers
{
    public class EventController : BaseController
    {
        private readonly IEventService _eventService;
        private readonly IFileDataService _fileDataService;
        private readonly IUserService _userService;

        #region Ctor

        public EventController(
            IEventService eventService,
            IFileDataService fileDataService,
            IUserService userService)
        {
            _eventService = eventService;
            _fileDataService = fileDataService;
            _userService = userService;
        }

        #endregion

        #region Actions

        [Authorize]
        public ActionResult Create()
        {
            try
            {
                var viewModel = GetEmptyEventViewModel();

                return View("CreateEvent", viewModel);
            }
            catch (Exception)
            {
                //todo: log error
                return RedirectToAction("Index", "Home");
            }
        }

        [Authorize]
        public ActionResult Clone(int id)
        {
            try
            {
                var @event = _eventService.GetEvent(id);
                var viewModel = GetEditEventViewModel(@event);

                return View("CreateEvent", viewModel);
            }
            catch (Exception)
            {
                //todo: log error
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(EditEventViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("CreateEvent", viewModel);
                }

                int? logoId = viewModel.LogoId;
                int? audioId = viewModel.AudioId;

                var logoFile = GetImageFileFromStream();
                if (logoFile != null && logoFile.ContentLength > 0)
                {
                    logoId = SaveFile(logoFile);
                }

                var audioFile = GetAudioFileFromStream();
                if (audioFile != null && audioFile.ContentLength > 0)
                {
                    audioId = SaveFile(audioFile);
                }

                var id = _eventService.CreateEvent(GetEventModel(viewModel, logoId, audioId));

                return RedirectToAction("Details", "Event", new { id = id });

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        //public ActionResult Edit(int id)
        //{
        //    try
        //    {
        //        var viewModel = GetEditableEventViewModel(id);

        //        return View("EditEvent", viewModel);
        //    }
        //    catch (Exception)
        //    {
        //        //todo: log error
        //        return RedirectToAction("Index", "Home");
        //    }
        //}

        public ActionResult Details(int id)
        {
            try
            {
                var viewModel = GetEventDetailsViewModel(id);

                return View(viewModel);
            }
            catch (Exception)
            {
                //todo: log error
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult GetEvents(DateTime startDate, DateTime endDate)
        {
            try
            {
                var events = _eventService.GetEvents(startDate, endDate);
                var jsonData = events.GroupBy(x => x.StartTime.Date).Select(d => new
                {
                    eventDate = d.Key.ToShortDateString(),
                    events = d.Select(x => new
                    {
                        eventId = x.Id,
                        logoUrl = x.LogoId.HasValue
                            ? Url.Action("Download", "FileData", new { id = x.LogoId })
                            : Url.Content("~/Content/Images/logo-default.jpg"),
                        audioUrl = x.AudioId.HasValue ? Url.Action("Download", "FileData", new { id = x.AudioId }) : null,
                        title = x.Title,
                        rate = x.Rate,
                        instruments = new
                        {
                            isGuitarUsed = x.IsGuitarUsed,
                            isViolinUsed = x.IsViolinUsed,
                            isVocalApplicable = x.IsVocalApplicable,
                            isSaxophoneUsed = x.IsSaxophoneUsed
                        }
                    })
                });

                return new SuccessJsonResult(jsonData);
            }
            catch (Exception)
            {
                return new HttpBadRequestResult();
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddComment(int eventId, string text)
        {
            try
            {
                var comment = new EventComment
                {
                    EventId = eventId,
                    Text = text,
                    UserId = UserId
                };
                _eventService.CreateComment(comment);
                return new SuccessJsonResult();
            }
            catch (Exception)
            {
                //todo: log error
                return new HttpBadRequestResult();
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult UpdateRating(int eventId, double rating)
        {
            try
            {
                var newRating = _eventService.UpdateRating(UserId, eventId, rating);
                return new SuccessJsonResult(newRating);
            }
            catch (Exception)
            {
                //todo: log error
                return new HttpBadRequestResult();
            }
        }

        #endregion

        #region Private Methods

        private EditEventViewModel GetEmptyEventViewModel()
        {
            var result = new EditEventViewModel()
            {
                StartTime = DateTime.Now
            };

            return result;
        }

        //private EditEventViewModel GetEditableEventViewModel(int eventId)
        //{
        //    var result = new EditEventViewModel();

        //    //todo: get data from service

        //    return result;
        //}

        private EventDetailsViewModel GetEventDetailsViewModel(int eventId)
        {
            var eventModel = _eventService.GetEvent(eventId);
            return GetEventDetailsViewModel(eventModel);
        }

        #region Logo

        private int? SaveFile(HttpPostedFileBase file)
        {
            var imageFile = new FileData
            {
                Data = ReadToEnd(file.InputStream),
                ContentType = file.ContentType
            };

            _fileDataService.Create(imageFile);
            return imageFile.Id;
        }

        private HttpPostedFileBase GetImageFileFromStream()
        {
            if (Request.Files.Count > 0)
            {
                var file = Request.Files["logo"];
                if (file.IsImage())
                {
                    return file;
                }
            }

            return null;
        }

        private HttpPostedFileBase GetAudioFileFromStream()
        {
            if (Request.Files.Count > 0)
            {
                return Request.Files["audio"];
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

        private EventModel GetEventModel(EditEventViewModel viewModel, int? logoId, int? audioId)
        {
            return new EventModel
            {
                AuthorId = User.Identity.GetUserId(),
                BriefDescription = viewModel.BriefDescription,
                StartTime = viewModel.StartTime,
                EndTime = viewModel.EndTime,
                FullDescription = viewModel.FullDescription,

                Title = viewModel.Title,
                LogoId = logoId,
                AudioId = audioId,

                Latitude = viewModel.Location.Latitude,
                Longitude = viewModel.Location.Longitude,

                IsGuitarUsed = viewModel.EventInstruments.IsGuitarUsed,
                IsViolinUsed = viewModel.EventInstruments.IsViolinUsed,
                IsVocalApplicable = viewModel.EventInstruments.IsVocalApplicable,
                IsSaxophoneUsed = viewModel.EventInstruments.IsSaxophoneUsed
            };
        }

        private EventDetailsViewModel GetEventDetailsViewModel(EventModel model)
        {
            return new EventDetailsViewModel
            {
                AuthorName = model.AuthorName,
                BriefDescription = model.BriefDescription,
                StartTime = model.StartTime,
                EndTime = model.EndTime,
                FullDescription = model.FullDescription,
                Location = new LocationViewModel
                {
                    Latitude = model.Latitude,
                    Longitude = model.Longitude,
                },
                EventInstruments = new EventInstrumentsViewModel()
                {
                    IsGuitarUsed = model.IsGuitarUsed,
                    IsViolinUsed = model.IsViolinUsed,
                    IsVocalApplicable = model.IsVocalApplicable,
                    IsSaxophoneUsed = model.IsSaxophoneUsed
                },
                Title = model.Title,
                LogoId = model.LogoId,
                AudioId = model.AudioId,
                IsRatingEditable = _eventService.IsRatingEditable(UserId, model.Id) && !string.IsNullOrEmpty(UserId),
                Rate = model.Rate,
                EventId = model.Id,
                AuthorId = model.AuthorId
            };
        }

        private EditEventViewModel GetEditEventViewModel(EventModel model)
        {
            return new EditEventViewModel
            {
                BriefDescription = model.BriefDescription,
                StartTime = model.StartTime,
                EndTime = model.EndTime,
                FullDescription = model.FullDescription,
                Location = new LocationViewModel
                {
                    Latitude = model.Latitude,
                    Longitude = model.Longitude,
                },
                EventInstruments = new EventInstrumentsViewModel()
                {
                    IsGuitarUsed = model.IsGuitarUsed,
                    IsViolinUsed = model.IsViolinUsed,
                    IsVocalApplicable = model.IsVocalApplicable,
                    IsSaxophoneUsed = model.IsSaxophoneUsed
                },
                Title = model.Title,
                AudioId = model.AudioId,
                LogoId = model.LogoId
            };
        }

        #endregion
    }
}