var map;
$(document).ready(function () {
    map = new GMaps({
        el: "#map",
        lat: 48.25177659267784,
        lng: 25.956519842147827,
        zoom: 6,
        click: function (e) {
            var list = vm.GetSelectedList();
            if (list == undefined || list == null) return;

            map.addMarker({
                lat: e.latLng.lat(),
                lng: e.latLng.lng()
            });

            list.classList.remove("selected");
            var listId = list.children[0].value;

            var data = {
                "ListId": listId,
                "Latitude": e.latLng.lat(),
                "Longitude": e.latLng.lng()
            };

            $.ajax({
                type: "POST",
                url: appContext.buildUrl("/api/lists/sendMarker/"),
                dataType: "json",
                beforeSend: function (xhr) { xhr.setRequestHeader("Authorization", "Bearer " + appContext.token); },
                data: data
            });

        }
    });

    //load coordinates for markers
    loadCoordinatesForMarkers();
});


var loadCoordinatesForMarkers = function () {
    $.ajax({
        type: "GET",
        beforeSend: function (xhr) { xhr.setRequestHeader("Authorization", "Bearer " + appContext.token); },
        url: appContext.buildUrl("/api/lists/getPoints"),
        dataType: "json",
        success: function (data) {

            //add markers to map
            $.each(data,
                function (index, marker) {
                    map.addMarker({
                        lat: marker.Latitude,
                        lng: marker.Longitude,
                        click: function (e) {

                            //set list selected
                            $.each($(".list"),
                                function (index, list) {
                                    if (list.children[0].value == marker.ListId) {

                                        if (list.classList.contains("selected")) {
                                            list.classList.remove("selected");
                                        }
                                        $(".list").each(function (index, element) {
                                            element.classList.remove("selected");
                                        });
                                        list.classList.add("selected");
                                        return false;
                                    }

                                });
                        }
                    });
                });
        }
    });
}

var SetMarkerInCenter = function (list) {
    var listId = list.children[0].value;

    $.ajax({
        type: "GET",
        beforeSend: function (xhr) { xhr.setRequestHeader("Authorization", "Bearer " + appContext.token); },
        url: appContext.buildUrl("/api/lists/getPoint/") + listId,
        dataType: "json",
        success: function (data) {
            if ((data.Latitude == 0 || data.Latitude == null) && (data.Longitude == 0 || data.Longitude == null)) return;

            map.setCenter(data.Latitude, data.Longitude);
            map.setZoom(9);
        }
    });
}

//selcte list on click on globeIcon
var selectList = function (span) {

    span.style.color = "black";
    var list = span.closest("li");

    if (list.classList.contains("selected")) {
        list.classList.remove("selected");
        return;
    }

    //remove all selected lists
    $('.list').each(function (index, element) {
        element.classList.remove("selected");
    });
    list.classList.add("selected");
}