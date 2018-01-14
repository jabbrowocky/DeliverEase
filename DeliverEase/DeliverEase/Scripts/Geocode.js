var map;

function initMap() {

    var location = { lat: 43.0389, lng: -87.9064 }
    var mapOptions = { zoom: 13, center: location }

    map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);
    var marker = new google.maps.Marker({ position: location, map: map })
}