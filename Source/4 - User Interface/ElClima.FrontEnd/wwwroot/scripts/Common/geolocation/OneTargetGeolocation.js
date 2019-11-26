var marker = null;
var defaultCenter = null;
var placeSearch, autocomplete;
var map = null;

function DrawMap() {
    if (!map) {
        if (vm.$data.p_selectedLocation.longitud !== 0 || vm.$data.p_selectedLocation.latitud !== 0) {
            defaultCenter = { lat: vm.$data.p_selectedLocation.latitud, lng: vm.$data.p_selectedLocation.longitud };
        } else {
            if (!defaultCenter) {
                defaultCenter = { lng: -64.1943410221038, lat: -31.399427685778598 };//Cordoba  
            }
        }

        map = new google.maps.Map(document.getElementById('map'), {
            center: defaultCenter,
            zoom: 18,
            mapTypeId: 'satellite'
        });

        addMarker(defaultCenter);

        map.addListener('click', function (event) {
            addMarker(event.latLng);
        });


        //Autocomplete configs
        var input = document.getElementById('pac-input');
        $("#pac-input").attr("placeholder", "");
        var searchBox = new google.maps.places.SearchBox(input);

        map.addListener('bounds_changed', function () {
            searchBox.setBounds(map.getBounds());
        });



        autocomplete = new google.maps.places.Autocomplete(document.getElementById('pac-input'), { types: ['geocode'] });

        autocomplete.addListener('place_changed', function () {
            actualizarMapa(); 
        });
        autocomplete.addListener('click', actualizarMapa);
    }
    
}

function actualizarMapa() { 

    var place = autocomplete.getPlace();

    var bounds = new google.maps.LatLngBounds(); 

    if (place.geometry.viewport) {
        bounds.union(place.geometry.viewport);
    } else {
        bounds.extend(place.geometry.location);
    } 
    map.fitBounds(bounds); 
    addMarker(bounds.getCenter());
}

function addMarker(location) {
    if (marker !== null) {
        marker.setMap(null);
    }
    marker = new google.maps.Marker({
        position: location,
        map: map
    });

    vm.$data.p_selectedLocation.latitud = typeof location.lat === 'function' ? location.lat() : location.lat;
    vm.$data.p_selectedLocation.longitud = typeof location.lng === 'function' ? location.lng() : location.lng;

    defaultCenter = { lat: vm.$data.p_selectedLocation.latitud, lng: vm.$data.p_selectedLocation.longitud };
     
} 

