 @{ string address = "'5352 N Kent Ave Milwaukee Wi'";}  
<script>
        //define currently local variables
        let address = @Html.Raw(address);
        
let formattedAddress = createAddressString(address);

//run corrected geocode address
var test;
geocode(formattedAddress);
console.log(test.results[0].geometry.location);
        
function geocode (geoAddress) {
    let location = geoAddress;
            
    jQuery.ajax({
        url: 'https://maps.google.com/maps/api/geocode/json?address=' + location + '&key=AIzaSyCxzznBe8ybNXYxz0ZOyhRJQbbVGvam75s',
        dataType: 'json',
        async: false,
        success: function (response) {
            console.log(response);
            test = response;                    
        }
    });            
}

//make '+'es between words in GET URL instead of spaces
function createAddressString(place) {
    let address = place.split(" ");
    let addressString = "";
    for (i = 0; i < address.length; i++) {
        if (i < address.length - 1) {
            addressString += address[i].toString() + "+";
        } else {
            addressString += address[i].toString();
        }
    }
    console.log(addressString);
    return addressString;
}

let map;

function initMap()
{
    let centerLocation =  test.results[0].geometry.location;
    // let location
    let mapOptions = { zoom: 13, center: centerLocation  };

    map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);
    //var marker = new google.maps.Marker({position: location , map: map})
    //addMarker(map, centerLocation);
    addMarker(map, test.results[0].geometry.location);
    //addMarker(map, jSonObject.results.0.geometry.location)
}


function addMarker(mapVar, location)
{
    let marker = new google.maps.Marker({ position: location, map: mapVar });
}   

</script>

<script async defer src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCxzznBe8ybNXYxz0ZOyhRJQbbVGvam75s&callback=initMap"></script>