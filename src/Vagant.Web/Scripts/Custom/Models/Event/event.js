var vagantApp = window.vagantApp || {};
vagantApp.event = vagantApp.event || {};

vagantApp.event.EventPage = function () {
    var self = this;
    self.rating = new vagantApp.event.StarRating();

    self.init = function (options) {
        self.rating.init(options);
    };
};

$(function () {
    var options = {};
    options.eventId = parseInt(vagantApp.event.eventId);
    options.rate = parseFloat(vagantApp.event.rate);
    options.updateRatingUrl = vagantApp.event.updateRatingUrl;
    options.isRatingEditable = vagantApp.event.isRatingEditable === 'true';

    var eventPage = new vagantApp.event.EventPage();
    eventPage.init(options);

    ko.applyBindings(eventPage);
});