var vagantApp = window.vagantApp || {};
vagantApp.event = vagantApp.event || {};

vagantApp.event.DetailsEventPage = function () {
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
        showMarker($('#latitude').val(), $('#longitude').val());
    }

    function showMarker(latitude, longitude) {
        self.map.setCenter(new google.maps.LatLng(latitude, longitude));
        self.marker = new google.maps.Marker({
            map: self.map,
            position: new google.maps.LatLng(latitude, longitude),
            draggable: false
        });
    }

    self.init = function () {
        init_map();
    }
};

$(function () {
    var page = new vagantApp.event.DetailsEventPage();
    page.init();
});