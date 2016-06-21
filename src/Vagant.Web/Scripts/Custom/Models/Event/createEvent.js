var vagantApp = window.vagantApp || {};
vagantApp.event = vagantApp.event || {};

vagantApp.event.CreateEvent = function () {
    var self = this;
    self.map = null;
    self.marker = null;

    function init_map() {
        var myOptions = {
            zoom: 10,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        self.map = new google.maps.Map(document.getElementById('gmap_canvas'), myOptions);
        navigator.geolocation.getCurrentPosition(showCurrentPosition);
    }

    function showCurrentPosition(position) {
        var latitude = position.coords.latitude;
        var longitude = position.coords.longitude;
        showMarker(latitude, longitude);
    }

    function showMarker(latitude, longitude) {
        $('#latitude').val(latitude);
        $('#longitude').val(longitude);

        self.map.setCenter(new google.maps.LatLng(latitude, longitude));
        self.marker = new google.maps.Marker({
            map: self.map,
            position: new google.maps.LatLng(latitude, longitude),
            draggable: true
        });
        google.maps.event.addListener(self.marker, 'dragend', function (evt) {
            $('#latitude').val(evt.latLng.lat());
            $('#longitude').val(evt.latLng.lng());
        });
    }

    self.init = function () {
        init_map();
        //google.maps.event.addDomListener(window, 'load', init_map);
    }
};

$(function () {
    var pageModel = new vagantApp.event.CreateEvent();
    pageModel.init();
});