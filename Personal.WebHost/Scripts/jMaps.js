//UPDATE MA_INSTANCIA
//SET V_GEO_LOCALIZACION=Geography::STPointFromText('POINT(LONG LAT)',4326)
//WHERE I_COD_INSTANCIA='50000'


(function () {
    var markers = [];
    var _latitude = null;
    var _longitude = null;
    var _op = new Array(2);
    _op["detMaps"] = 0;
    _op["inputMaps"] = 1;

    var ctrl = {
        latitude: null,
        longitude: null,
        //cuanfo e intepreta y no se crea un proceso    ue se ejecute este obtendra la latitude y long nullas que fueron inicializada
        //mapOptions: {http://blog.mridey.com/2010/11/maps-api-javascript-v3-multiple-markers_08.html
        //    center: new google.maps.LatLng(_latitude, _longitude),
        //    zoom: 13,
        //    _latitude: _latitude
        //},
        mapSearch: null,
        mapOptions: null,
        map: null,
        canvas: null,
        bounds: null,
        point: null,
        optMaps: window.parent.length > 0 ? window.parent.document.querySelector("[data-op-maps]").value : document.querySelector("[data-op-maps]").value,

    }

    var tags = function () {
        var streetview = null;
        var $private = {
            setBounds: function () {
                var ret = new google.maps.LatLngBounds()
                ctrl.bounds = ret;
            },
            setPoint: function () {
                var ret = new google.maps.LatLng(_latitude, _longitude);
                ctrl.point = ret;
            },
            hideSearch: function () {
                ctrl.mapSearch.style.display = "none"
            },
            setMapSearch: function () {
                ctrl.mapSearch = document.getElementById("mapSearch");
            },
            setMap: function () {
                ctrl.canvas = document.getElementById('map-canvas');
                ctrl.map = new google.maps.Map(ctrl.canvas, ctrl.mapOptions);
            }
            ,
            setMapOtions: function () {
                ctrl.mapOptions = {
                    center: new google.maps.LatLng(_latitude, _longitude),
                    zoom: 17
                };
            },
            GetOptionMaps: function () {

                return _op[ctrl.optMaps];
            },
            setGetInfoWindow: function (name) {
                var content = document.createElement("DIV");
                var title = document.createElement("DIV");
                title.innerHTML = name;
                title.style.marginBottom = "10px";
                content.style.color = "rgb(92, 93, 178)";
                content.style.fontWeight = "bold";
                content.appendChild(title);
                streetview = document.createElement("DIV");
                streetview.style.width = "200px";
                streetview.style.height = "200px";
                content.appendChild(streetview);
                var infowindow = new google.maps.InfoWindow({
                    content: content
                });


                return infowindow;
            }
        }
        //http://www.maestrosdelweb.com/consejos-practicos-infowindow-google-maps/

        this.addMarker = function (location) {

            var marker = new google.maps.Marker({
                position: location,
                map: ctrl.map

            });

            for (var i = 0; i < markers.length; i++) {

                markers[i].setMap(null);
            }
            markers.push(marker);
            var infoWindow = null;
            if ($private.GetOptionMaps() == 0) {
                alert(location + ' 2/// ')
                infoWindow = $private.setGetInfoWindow('dffdfdfd');
                infoWindow.open(ctrl.map, marker);
                //          return false;
            } else {
                infoWindow = $private.setGetInfoWindow('Posicion Capturada');
            }

            google.maps.event.addListener(marker, 'dblclick', function (event) {
                var latLng = event.latLng.toString();
                var latitude = latLng.substr(1, latLng.toString().indexOf(",") - 1);
                var longitude = latLng.substr(latLng.toString().indexOf(",") + 1, latLng.length - latLng.toString().indexOf(",")).replace(")", "");

                if (typeof (window.parent.document.getElementById("latitude")) != 'undefined') {
                    window.parent.document.getElementById("latitude").value = parseFloat(latitude).toFixed(6)
                    window.parent.document.getElementById("longitude").value = parseFloat(longitude).toFixed(6)
                }
                infoWindow.open(ctrl.map, marker);

            })
            google.maps.event.addListenerOnce(infoWindow, "domready", function () {
                var panorama = new google.maps.StreetViewPanorama(streetview, {
                    navigationControl: false,
                    enableCloseButton: false,
                    addressControl: false,
                    linksControl: false,
                    visible: true,
                    position: marker.getPosition()
                });
            });

        }

        this.setLatLong = function () {
            _latitude = ctrl.latitude;
            _longitude = ctrl.longitude;
        }
        this.setCtrlLatLong = function (i) {
            if (typeof (window.parent.document.getElementById("latitude")) !== 'undefined' && window.parent.document.getElementById("latitude").value != '') {
                ctrl.latitude = parseFloat(window.parent.document.getElementById("latitude").value.replace(",", ".")).toFixed(6);
                ctrl.longitude = parseFloat(window.parent.document.getElementById("longitude").value.replace(",", ".")).toFixed(6);
            } else {
                ctrl.latitude = -12.191089
                ctrl.longitude = -76.932189
            }
            alert(ctrl.latitude)
            alert(ctrl.longitude)
        }
        this.Automcomplete = function () {

            var input = (document.getElementById('pac-input'))
            var types = document.getElementById('type-selector');
            ctrl.map.controls[google.maps.ControlPosition.TOP_LEFT].push(input);
            ctrl.map.controls[google.maps.ControlPosition.TOP_LEFT].push(types);
            var autocomplete = new google.maps.places.Autocomplete(input);
            autocomplete.bindTo('bounds', ctrl.map);

            var infowindow = new google.maps.InfoWindow();
            var marker = new google.maps.Marker({
                map: ctrl.map
            });


            google.maps.event.addListener(autocomplete, 'place_changed', function () {
                infowindow.close();
                marker.setVisible(false);
                var place = autocomplete.getPlace();
                if (!place.geometry) {
                    return;
                }
                // If the place has a geometry, then present it on a map.
                if (place.geometry.viewport) {
                    ctrl.map.fitBounds(place.geometry.viewport);
                } else {
                    ctrl.map.setCenter(place.geometry.location);
                    ctrl.map.setZoom(17);  // Why 17? Because it looks good.
                }
                marker.setIcon(({
                    url: place.icon,
                    size: new google.maps.Size(71, 71),
                    origin: new google.maps.Point(0, 0),
                    anchor: new google.maps.Point(17, 34),
                    scaledSize: new google.maps.Size(35, 35)
                }));
                marker.setPosition(place.geometry.location);
                marker.setVisible(true);

                var address = '';
                if (place.address_components) {
                    address = [
                      (place.address_components[0] && place.address_components[0].short_name || ''),
                      (place.address_components[1] && place.address_components[1].short_name || ''),
                      (place.address_components[2] && place.address_components[2].short_name || '')
                    ].join(' ');
                }
                infowindow.setContent('<div><strong>' + place.name + '</strong><br>' + address);
                infowindow.open(ctrl.map, marker);
            });

            // Sets a listener on a radio button to change the filter type on Places
            // Autocomplete.
            function setupClickListener(id, types) {
                var radioButton = document.getElementById(id);
                google.maps.event.addDomListener(radioButton, 'click', function () {
                    autocomplete.setTypes(types);
                });
            }

            setupClickListener('changetype-all', []);
            //setupClickListener('changetype-establishment', ['establishment']);
            //setupClickListener('changetype-geocode', ['geocode']);
        }
        this.CallEventForOption = function () {

            switch ($private.GetOptionMaps()) {
                case 0:
                    this.setCtrlLatLong(0);
                    this.setLatLong();
                    $private.hideSearch();
                    $private.setMapOtions();
                    $private.setMap();
                    $private.setBounds();
                    $private.setPoint();
                    ctrl.bounds.extend(ctrl.point);
                    this.addMarker(ctrl.point);

                    break;
                case 1:
                    this.setCtrlLatLong(1);
                    this.setLatLong();
                    $private.setMapOtions();
                    $private.setMap();
                    $private.setBounds();
                    $private.setPoint();
                    ctrl.bounds.extend(ctrl.point);
                    var t = this.addMarker;
                    this.Automcomplete();
                    google.maps.event.addListener(ctrl.map, 'click', function (event) {
                        t(event.latLng);
                    });

                    break;
                default:
                    break;
            }
        }

        this.initializeData = function () {
            $private.setMapSearch();
        }

    }

    var handles = function () {
        tags.call(handles)
        that = this;
        var _listener = {
            initialize: function () {
                google.maps.event.addDomListener(window, 'load', this.load);
            },
            load: function () {
                that.initializeData();
                that.CallEventForOption();
            }
        }

        this.initialize = function () {
            _listener.initialize();
        };
    }
    handles.prototype = new tags();
    handles.prototype.constructor = handles;

    var ref = new handles();
    ref.initialize();
})()

////---------------------------------------

//var markers = []
//var _latitude = window.parent.document.getElementById("latitude").value.replace(",", ".");
//var _longitude = window.parent.document.getElementById("longitude").value.replace(",", ".");

//function initialize() {

//    var mapOptions = {
//        center: new google.maps.LatLng(_latitude, _longitude),
//        zoom: 13
//    };
//    var map = new google.maps.Map(document.getElementById('map-canvas'),
//      mapOptions);

//    var bounds = new google.maps.LatLngBounds();
//    var point = new google.maps.LatLng(_latitude, _longitude);
//    bounds.extend(point);
//    addMarker(point);
//    google.maps.event.addListener(map, 'click', function (event) {
//        alert(event.latLng)
//        addMarker(event.latLng);

//    });
//    var input = (
//        document.getElementById('pac-input'));

//    var types = document.getElementById('type-selector');
//    map.controls[google.maps.ControlPosition.TOP_LEFT].push(input);
//    map.controls[google.maps.ControlPosition.TOP_LEFT].push(types);

//    var autocomplete = new google.maps.places.Autocomplete(input);
//    autocomplete.bindTo('bounds', map);

//    var infowindow = new google.maps.InfoWindow();
//    var marker = new google.maps.Marker({
//        map: map
//    });

//    google.maps.event.addListener(autocomplete, 'place_changed', function () {
//        infowindow.close();
//        marker.setVisible(false);
//        var place = autocomplete.getPlace();
//        if (!place.geometry) {
//            return;
//        }

//        // If the place has a geometry, then present it on a map.
//        if (place.geometry.viewport) {
//            map.fitBounds(place.geometry.viewport);
//        } else {
//            map.setCenter(place.geometry.location);
//            map.setZoom(17);  // Why 17? Because it looks good.
//        }
//        marker.setIcon(({
//            url: place.icon,
//            size: new google.maps.Size(71, 71),
//            origin: new google.maps.Point(0, 0),
//            anchor: new google.maps.Point(17, 34),
//            scaledSize: new google.maps.Size(35, 35)
//        }));
//        marker.setPosition(place.geometry.location);
//        marker.setVisible(true);

//        var address = '';
//        if (place.address_components) {
//            address = [
//              (place.address_components[0] && place.address_components[0].short_name || ''),
//              (place.address_components[1] && place.address_components[1].short_name || ''),
//              (place.address_components[2] && place.address_components[2].short_name || '')
//            ].join(' ');
//        }

//        infowindow.setContent('<div><strong>' + place.name + '</strong><br>' + address);
//        infowindow.open(map, marker);

//    });

//    // Sets a listener on a radio button to change the filter type on Places
//    // Autocomplete.
//    function setupClickListener(id, types) {
//        var radioButton = document.getElementById(id);
//        google.maps.event.addDomListener(radioButton, 'click', function () {
//            autocomplete.setTypes(types);
//        });
//    }

//    setupClickListener('changetype-all', []);
//    //setupClickListener('changetype-establishment', ['establishment']);
//    //setupClickListener('changetype-geocode', ['geocode']);

//    function addMarker(location) {
//        var infowindow = new google.maps.InfoWindow({
//            content: "<div class='infoDiv'><h2>" +
//             "d" + "</h2>" + "<div><h4>Opening hours: " +
//              "dd" + "</h4></div></div>"
//        });
//        var marker = new google.maps.Marker({
//            position: location,
//            map: map
//        });

//        //google.maps.event.addListener(marker, 'lo', function () {

//        infowindow.open(map, marker);
//        //        });


//        //for (var i = 0; i < markers.length; i++) {

//        //    markers[i].setMap(null);
//        //}

//        //markers.push(marker);

//        //var q = location;//16
//        //var url = "http://maps.google.com/maps/api/staticmap?center=" + q.toString() + "&zoom=16&size=3500x712&maptype=roadmap&sensor=true&markers=" + q.toString();
//        //var elementoImg = document.createElement('img');
//        //elementoImg.setAttribute('src', url);

//        //var capaParent = document.getElementById("img");
//        //capaParent.appendChild(elementoImg);

//        //  parent.document.getElementById("V_DES_IMAGEN").value = url;


//    }
//}

//google.maps.event.addDomListener(window, 'load', initialize);

