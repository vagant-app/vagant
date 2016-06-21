var vagantApp = window.vagantApp || {};
vagantApp.event = vagantApp.event || {};

vagantApp.event.EventListItem = function () {
    var self = this;

    //#region Properties
    self.title = ko.observable('');
    self.id = ko.observable('');
    self.logoUrl = ko.observable('');
    self.audioUrl = ko.observable('');
    self.isBeingPlayed = ko.observable(false);
    self.rate = ko.observable(null);
    self.date = null;

    self.instruments = new vagantApp.event.EventInstrumentModel();
    //#endregion

    //#region Computed
    self.eventDetailsPageUrl = ko.computed(function(){
        var prefixUrl = vagantAppParams ? vagantAppParams.gotoEventsDetailsUrl : '';
        return prefixUrl + '?id=' + self.id();
    });

    self.isPlayerControlPaneVisible = ko.computed(function () {
        var audioUrl = self.audioUrl();
        return audioUrl;
    });
    //#endregion

    //#region Public functions
    self.loadData = function (dataObject) {
        if (dataObject) {
            self.id(dataObject.eventId);
            self.title(dataObject.title);
            self.logoUrl(dataObject.logoUrl);
            self.audioUrl(dataObject.audioUrl);
            self.date = dataObject.date;
            self.rate(dataObject.rate);

            self.instruments.loadData(dataObject.instruments);
        }
    };

    self.open = function () {
        location = self.eventDetailsPageUrl();
    };

    self.updatePlayerStatus = function (isPlayed) {
        self.isBeingPlayed(isPlayed);
    };
    //#endregion
};