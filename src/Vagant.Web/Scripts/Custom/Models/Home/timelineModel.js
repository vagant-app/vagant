var vagantApp = window.vagantApp || {};
vagantApp.home = vagantApp.home || {};

vagantApp.home.Timeline = function () {
    var self = this;

    var handler = null;

    //#region Properties
    self.dates = ko.observableArray([]);
    //#endregion

    //#region Public functions
    self.loadDates = function (dates) {
        self.dates.removeAll();
        if (dates) {
            self.dates(dates.slice(0));
        }
    };

    self.selectDate = function (element, information) {
        if (handler && typeof handler === 'function') {
            handler(information.on);
        }
    };

    self.setSelectDateHandler = function (handlerFunction) {
        handler = handlerFunction;
    };
    //#endregion
};