var vagantApp = window.vagantApp || {};
vagantApp.event = vagantApp.event || {};

vagantApp.event.InstrumentFilter = function (changeHandler) {
    var self = this;

    //#region Fields
    var filterChangeHandler = null;
    //#endregion

    //#region Properties
    self.isGuitarUsed = ko.observable(false);
    self.isViolinUsed = ko.observable(false);
    self.isSaxophoneUsed = ko.observable(false);
    self.isVocalUsed = ko.observable(false);
    //#endregion

    //#region Private functions
    var getFilterFunction = function () {
        var isGuitarRequired = self.isGuitarUsed();
        var isViolinRequired = self.isViolinUsed();
        var isVocalRequired = self.isVocalUsed();
        var isSaxophoneRequired = self.isSaxophoneUsed();

        var filterFunction = function (eventObject) {
            if (eventObject && eventObject.instruments) {
                var instruments = eventObject.instruments;
                if (isGuitarRequired && !instruments.isGuitarUsed) {
                    return false;
                }

                if (isViolinRequired && !instruments.isViolinUsed) {
                    return false;
                }

                if (isSaxophoneRequired && !instruments.isSaxophoneUsed) {
                    return false;
                }

                if (isVocalRequired && !instruments.isVocalApplicable) {
                    return false;
                }

                return true;
            }
            return false;
        };
        return filterFunction;
    };

    var handleFilterStateChange = function () {
        if (filterChangeHandler && typeof filterChangeHandler === 'function') {
            filterChangeHandler();
        }
    };
    //#endregion

    //#region Subscribers
    self.isGuitarUsed.subscribe(handleFilterStateChange);
    self.isGuitarUsed.subscribe(handleFilterStateChange);
    self.isVocalUsed.subscribe(handleFilterStateChange);
    self.isSaxophoneUsed.subscribe(handleFilterStateChange);
    //#endregion

    //#region Public functions
    self.initChangeHandler = function (handler) {
        filterChangeHandler = handler ? handler : null;
    };

    self.getFilter = function () {
        return getFilterFunction();
    };

    self.clickGuitar = function () {
        self.isGuitarUsed(!self.isGuitarUsed());
    };

    self.clickViolin = function () {
        self.isViolinUsed(!self.isViolinUsed());
    };

    self.clickVocal = function () {
        self.isVocalUsed(!self.isVocalUsed());
    };

    self.clickSaxophone = function () {
        self.isSaxophoneUsed(!self.isSaxophoneUsed());
    };

    self.resetFilter = function () {
        self.isGuitarUsed(false);
        self.isViolinUsed(false);
        self.isSaxophoneUsed(false);
        self.isVocalUsed(false);
    };
    //#endregion
};