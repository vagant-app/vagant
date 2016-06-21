var vagantApp = window.vagantApp || {};
vagantApp.sound = vagantApp.sound || {};

vagantApp.sound.Player = function () {
    var self = this;

    //#region Fields
    var instance = null;
    //#endregion

    //#region Public functions
    self.load = function (url) {
        self.pause();
        if (url) {
            instance = new Audio(url);
        }
    };

    self.play = function () {
        self.pause();
        if (instance) {
            instance.play();
        }
    };

    self.pause = function () {
        if (instance) {
            instance.pause();
        }
    };
    //#endregion
};