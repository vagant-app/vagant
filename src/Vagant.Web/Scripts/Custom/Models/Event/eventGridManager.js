var vagantApp = window.vagantApp || {};
vagantApp.event = vagantApp.event || {};

vagantApp.event.EventGridManager = function () {
    var self = this;

    //#region
    var DaysInterval = 30;
    //#endregion

    //#region Fields
    var loadedEvents = [];
    var loadedDates = [];
    var getEventsDataUrl = null;
    var dateFilterFunction = null;
    //#endregion

    //#region Properties
    self.eventList = new vagantApp.event.EventList();
    self.timeline = new vagantApp.home.Timeline();
    self.instrumentFilter = new vagantApp.event.InstrumentFilter();
    //#endregion

    //#region Private functions
    var getEventsData = function () {
        var deferredObject = $.Deferred();

        if (getEventsDataUrl) {
            var currentDate = new Date();
            var startDate = new Date(currentDate);
            startDate.setDate(currentDate.getDate() - DaysInterval);
            var endDate = new Date(currentDate);
            endDate.setDate(currentDate.getDate() + DaysInterval);
            var requestDataObject = {
                startDate: startDate.toDateString(),
                endDate: endDate.toDateString()
            };

            $.ajax({
                url: getEventsDataUrl,
                data: requestDataObject,
                success: function (response) {
                    if (response && response.isSuccess) {
                        deferredObject.resolve(response.data);
                        return;
                    }

                    deferredObject.reject();
                },
                error: function () {
                    deferredObject.reject();
                }
            });
        } else {
            deferredObject.reject();
        }

        return deferredObject.promise();
    };

    var loadEvents = function (eventDatesList) {
        loadedEvents = [];
        loadedDates = [];
        if (eventDatesList) {
            ko.utils.arrayForEach(eventDatesList, function (eventDateObject) {
                if (eventDateObject) {
                    loadedDates.push(new Date(eventDateObject.eventDate));
                    if (eventDateObject.events) {
                        ko.utils.arrayForEach(eventDateObject.events, function (eventObject) {
                            eventObject.date = eventDateObject.eventDate;
                            loadedEvents.push(eventObject);
                        })
                    }
                }
            });
        }
    };

    var updateDates = function () {
        self.timeline.loadDates(loadedDates);
    };

    var updateVisibleEventsList = function(dateFilter, instrumentsFilter){
        var itemsToLoad = [];
        if (loadedEvents && loadedEvents.length > 0) {
            ko.utils.arrayForEach(loadedEvents, function (eventObject) {
                if (dateFilter && typeof dateFilter === 'function') {
                    if (!dateFilter(eventObject)) {
                        return;
                    }
                }

                if (instrumentsFilter && typeof instrumentsFilter === 'function') {
                    if (!instrumentsFilter(eventObject)) {
                        return;
                    }
                }

                itemsToLoad.push(eventObject);
            });
        }

        self.eventList.loadData(itemsToLoad);
    };

    var handleDateOrInstrumentFilterChange = function () {
        var instrumentFilterFunction = self.instrumentFilter.getFilter();

        updateVisibleEventsList(dateFilterFunction, instrumentFilterFunction);
    }

    var dateSelectedHandler = function (date) {
        var dateString = date.toLocaleDateString();
        var filterFunction = function (eventObject) {
            if (eventObject) {
                return eventObject.date === dateString;
            }
            return false;
        };
        dateFilterFunction = filterFunction;
        var instrumentFilterFunction = self.instrumentFilter.getFilter();

        updateVisibleEventsList(filterFunction, instrumentFilterFunction);
    };
    //#endregion

    //#region Public functions
    self.init = function (options, player) {
        if (options) {
            getEventsDataUrl = options.getEventsDataUrl;
            self.eventList.setBusy();
            getEventsData()
                .done(function (events) {
                    loadEvents(events);
                    updateDates();
                    updateVisibleEventsList();
                })
                .always(self.eventList.setReady);
        }

        self.instrumentFilter.initChangeHandler(handleDateOrInstrumentFilterChange);
        self.eventList.setPlayerReferrence(player);
        self.timeline.setSelectDateHandler(dateSelectedHandler);
    };

    self.resetFilters = function () {
        dateFilterFunction = null;
        self.instrumentFilter.resetFilter();
        updateVisibleEventsList();
    };
    //#endregion
};