var vagantApp = window.vagantApp || {};
vagantApp.event = vagantApp.event || {};

vagantApp.event.StarRating = function () {
    var self = this;
    var updateRatingUrl = null;
    var eventId = 0;

    self.ratingValue = ko.observable(0);
    self.isEditable = ko.observable(true);

    self.ratingChaged = function (element, newValue) {
        $.ajax({
            method: "POST",
            url: updateRatingUrl,
            data: { eventId: eventId, rating: newValue },
            success: function (response) {
                $(element).val(response.data);
                $(element).rating('refresh', {
                    disabled: true
                });
            }
        });
    };

    self.init = function (options) {
        self.ratingValue(options.rate);
        self.isEditable(options.isRatingEditable);
        updateRatingUrl = options.updateRatingUrl;
        eventId = options.eventId;
    };
};