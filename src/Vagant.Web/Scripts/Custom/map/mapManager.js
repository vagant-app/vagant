var vagantApp = window.vagantApp || {};
vagantApp.maps = vagantApp.maps || {};

vagantApp.maps.MapManager = function (clickEventHandler) {
    var self = this;

    //#region Fields
    var map = null;
    var clickHandler = clickEventHandler ? clickEventHandler : null;

    var mapConfigurationObject = {};
    //#endregion

    //#region Private functions
    var mapClickEventHandler = function (latLng) {
        if (clickHandler && typeof clickHandler === 'typeof') {
            clickHandler(latLng.lat(), latLng.lng());
        }
    };
    //#endregion

    //#region Public functions
    self.init = function (containerElementId) {
        map = new google.maps.Map(document.getElementById(containerElementId), mapConfigurationObject);

        map.addListener('click', mapClickEventHandler);
    };
    //#endregion
};