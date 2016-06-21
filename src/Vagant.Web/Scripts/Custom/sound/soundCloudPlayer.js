var vagantApp = window.vagantApp || {};
vagantApp.sound = vagantApp.sound || {};

vagantApp.sound.SoundCloudPlayer = function () {
    var self = this;

    //#region Fields
    var widget = null;
    //#endregion

    //#region Private functions
    //#endregion

    //#region Public functions
    self.init = function () {
        var widgetIframe = document.getElementById('testFrame'),
        widget = SC.Widget(widgetIframe),
        newSoundUrl = 'http://api.soundcloud.com/tracks/13692671';

        //widget.load(newSoundUrl, {
        //    show_artwork: false
        //});

        //widget.bind(SC.Widget.Events.READY, function () {
        //    // load new widget
        //    widget.bind(SC.Widget.Events.FINISH, function () {
        //        widget.load(newSoundUrl, {
        //            show_artwork: false
        //        });
        //    });
        //});
    };
    //#endregion
};