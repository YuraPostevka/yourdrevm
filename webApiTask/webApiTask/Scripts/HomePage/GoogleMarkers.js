var map;
$(document).ready(function () {
    map = new GMaps({
        el: "#map",
        lat: 48.25177659267784,
        lng: 25.956519842147827,
        zoom: 15,
        click: function (e) {
            map.addMarker({
                lat: e.latLng.lat(),
                lng: e.latLng.lng()
            });
        }s
    });
});