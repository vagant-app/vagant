using System;
using System.Collections.Generic;
using System.Linq;
using Vagant.Domain.Entities;
using Vagant.Domain.Models;
using Vagant.Domain.Services;
using Vagant.Domain.UnitOfWork;

namespace Vagant.Business.Services
{
    public class EventService : IEventService
    {
        private readonly IAppUnitOfWork _uow;

        public EventService(IAppUnitOfWork uow)
        {
            _uow = uow;
        }

        public int CreateEvent(EventModel model)
        {
            var eventRepository = _uow.GetRepository<Event>();

            var @event = new Event
            {
                Location = new Location(),
                EventInstrument = new EventInstrument()
            };

            MapToEntity(model, @event);
            eventRepository.Create(@event);
            _uow.Commit();

            return @event.Id;
        }

        public void UpdateEvent(EventModel model)
        {
            var eventRepository = _uow.GetRepository<Event>();

            var @event = eventRepository.GetByKey(model.Id);
            if (@event == null)
            {
                throw new ArgumentNullException();
            }

            MapToEntity(model, @event);
            eventRepository.Update(@event);
            _uow.Commit();
        }

        public double UpdateRating(string userId, int eventId, double ratingValue)
        {
            var eventRepository = _uow.GetRepository<Event>();
            var eventRatingRepository = _uow.GetRepository<EventRating>();

            eventRatingRepository.Create(new EventRating
            {
                EventId = eventId,
                RatingValue = ratingValue,
                VoterId = userId
            });
            _uow.Commit();

            var @event = eventRepository.GetByKey(eventId);
            var ratings = eventRatingRepository.Get(x => x.EventId == eventId);

            @event.Rate = (double)ratings.Sum(x => x.RatingValue) / ratings.Count();
            eventRepository.Update(@event);
            _uow.Commit();

            return @event.Rate;
        }

        public bool IsRatingEditable(string userId, int eventId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return false;
            }

            var eventRatingRepository = _uow.GetRepository<EventRating>();
            return eventRatingRepository.Get(x => x.VoterId == userId && x.EventId == eventId).Count() == 0;
        }

        public EventModel GetEvent(int eventId)
        {
            var eventRepository = _uow.GetRepository<Event>();
            var @event = eventRepository.GetByKey(eventId);
            return GetModel(@event);
        }

        public IList<EventModel> GetEvents(DateTime startDate, DateTime endDate)
        {
            var eventRepository = _uow.GetRepository<Event>();
            var events = eventRepository.Get(x => x.StartTime >= startDate.Date && x.StartTime <= endDate.Date);
            return events.Select(GetModel).ToList();
        }

        public void CreateComment(EventComment comment)
        {
            var commentRepository = _uow.GetRepository<EventComment>();

            commentRepository.Create(comment);
            _uow.Commit();
        }

        public IList<EventModel> GetUserEvents(string userId)
        {
            var eventRepository = _uow.GetRepository<Event>();
            var events = eventRepository.Get(x => x.AuthorId == userId);
            return events.Select(GetModel).ToList();
        }

        #region Private Methods

        private void MapToEntity(EventModel model, Event entity)
        {
            entity.AuthorId = model.AuthorId;
            entity.BriefDescription = model.BriefDescription;
            entity.EndTime = model.EndTime;
            entity.FullDescription = model.FullDescription;
            entity.LogoId = model.LogoId;
            entity.AudioId = model.AudioId;
            entity.StartTime = model.StartTime;
            entity.Title = model.Title;

            if (entity.Location != null)
            {
                entity.Location.Latitude = model.Latitude;
                entity.Location.Longitude = model.Longitude;
            }

            if (entity.EventInstrument != null)
            {
                entity.EventInstrument.IsGuitarUsed = model.IsGuitarUsed;
                entity.EventInstrument.IsViolinUsed = model.IsViolinUsed;
                entity.EventInstrument.IsVocalApplicable = model.IsVocalApplicable;
                entity.EventInstrument.IsSaxophoneUsed = model.IsSaxophoneUsed;
            }
        }

        private EventModel GetModel(Event entity)
        {
            var model = new EventModel();

            model.Id = entity.Id;
            model.AuthorId = entity.AuthorId;
            model.BriefDescription = entity.BriefDescription;
            model.EndTime = entity.EndTime;
            model.FullDescription = entity.FullDescription;
            model.LogoId = entity.LogoId;
            model.AudioId = entity.AudioId;
            model.StartTime = entity.StartTime;
            model.Title = entity.Title;
            model.AuthorName = string.Format("{0} {1}", entity.Author.FirstName, entity.Author.LastName);
            model.Rate = entity.Rate;

            if (entity.Location != null)
            {
                model.Latitude = entity.Location.Latitude;
                model.Longitude = entity.Location.Longitude;
            }

            if (entity.EventInstrument != null)
            {
                model.IsGuitarUsed = entity.EventInstrument.IsGuitarUsed;
                model.IsViolinUsed = entity.EventInstrument.IsViolinUsed;
                model.IsVocalApplicable = entity.EventInstrument.IsVocalApplicable;
                model.IsSaxophoneUsed = entity.EventInstrument.IsSaxophoneUsed;
            }

            return model;
        }

        #endregion
    }
}
