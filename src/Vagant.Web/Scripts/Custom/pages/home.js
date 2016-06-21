var vagantApp = window.vagantApp || {};
vagantApp.pages = vagantApp.pages || {};

vagantApp.pages.Home = function () {
    var self = this;

    //#region Properties
    self.gridManager = new vagantApp.event.EventGridManager();
    self.player = new vagantApp.sound.Player();
    //#endregion

    //#region Private functions
    //#endregion

    //#region Public functions
    self.init = function (options) {
        self.gridManager.init(options, self.player);
    };
    //#endregion
};

$(function () {
    var pageModel = new vagantApp.pages.Home();

    ko.applyBindings(pageModel);

    pageModel.init(vagantAppParams);
});