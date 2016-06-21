var vagantApp = window.vagantApp || {};
vagantApp.event = vagantApp.event || {};

vagantApp.event.CreateEventPage = function () {
    var self = this;
    self.map = null;
    self.marker = null;

    function init_map() {
        var myOptions = {
            zoom: 12,
            mapTypeId: google.maps.MapTypeId.ROADMAP,
            zoomControl: true,
            mapTypeControl: false,
            scaleControl: true,
            streetViewControl: false,
            rotateControl: false,
            fullscreenControl: false
        };

        var styles = [
          {
              stylers: [
                { hue: "#00ffe6" },
                { saturation: -20 }
              ]
          }, {
              featureType: "road",
              elementType: "geometry",
              stylers: [
                { lightness: 100 },
                { visibility: "simplified" }
              ]
          }, {
              featureType: "road",
              elementType: "labels",
              stylers: [
                { visibility: "off" }
              ]
          }
        ];

        self.map = new google.maps.Map(document.getElementById('gmap_canvas'), myOptions);
        self.map.setOptions({ styles: styles });
        if ($('#latitude').val() == 0 && $('#longitude').val() == 0)
        {
            navigator.geolocation.getCurrentPosition(showCurrentPosition);
        } else {
            showMarker($('#latitude').val(), $('#longitude').val());
        }
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
    var page = new vagantApp.event.CreateEventPage();
    page.init();
});