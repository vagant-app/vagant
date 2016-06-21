var vagantApp = window.vagantApp || {};
vagantApp.event = vagantApp.event || {};

vagantApp.event.EventInstrumentModel = function () {
    var self = this;

    //#region Properties
    self.isGuitarUsed = ko.observable(false);
    self.isViolinUsed = ko.observable(false);
    self.isSaxophoneUsed = ko.observable(false);
    self.isVocalApplicable = ko.observable(false);
    //#endregion

    //#region Public functions
    self.loadData = function (dataObject) {
        if (dataObject) {
            self.isGuitarUsed(dataObject.isGuitarUsed);
            self.isViolinUsed(dataObject.isViolinUsed);
            self.isSaxophoneUsed(dataObject.isSaxophoneUsed);
            self.isVocalApplicable(dataObject.isVocalApplicable);
        }
    };
    //#endregion
};