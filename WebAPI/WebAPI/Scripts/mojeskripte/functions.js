function startApp() {
    $("div#logDiv").load("./htmlStranice/login.html");
}

function startPocetna() {
    $("div#pocetnaDiv").load("./htmlStranice/musterija.html");
}

function startDispecer() {
    $("div#pocetnaDiv").load("./htmlStranice/dispecer.html");
}

function startVozac() {
    $("div#pocetnaDiv").load("./htmlStranice/vozac.html");
}

function loadKomentarVozac() {
    $("div#pocetnaDiv").load("./htmlStranice/HtmlKomentarVozac.html");
}

function loadUnosOdredista() {
    $("div#pocetnaDiv").load("./htmlStranice/HtmlUnosOdredista.html");
}

function loadKomentarMusterija() {
    $("div#pocetnaDiv").load("./htmlStranice/HtmlKomentarMusterija.html");
}

function doRegistrationSubmit() {

    let korisnik = {
        KorisnickoIme: `${$('#ki').val()}`,
        Lozinka: `${$('#lozinka').val()}`,
        Ime: `${$('#ime').val()}`,
        Prezime: `${$('#prezime').val()}`,
        Pol: `${$('#pol').val()}`,
        Jmbg: `${$('#jmbg').val()}`,
        KontaktTelefon: `${$('#telefon').val()}`,
        Email: `${$('#email').val()}`,

    }

    $.ajax({
        url: '/api/loggin/',
        method: 'POST',
        data: JSON.stringify(korisnik),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (data) {
            alert(data.KorisnickoIme);
            startApp();
        },
        error: function (jqXHR) {
            alert(jqXHR.responseJSON["Message"]); 
            $("div#errdiv").text(jqXHR.responseJSON["Message"]).show();
        }
    });

    /*$.post('/api/loggin/', $('form#regForm').serialize())
        .done(function (status, data, xhr) {
            alert(data);
            startApp();
        }).fail(function (jqXHR, textStatus) {
            alert(jqXHR.responseJSON["Message"]);
        });*/
}

function promena() {

    let korisnik = {
        KorisnickoIme: `${$('#korisnickoImePromena').val()}`,
        Lozinka: `${$('#lozinkaPromena').val()}`,
        Ime: `${$('#imePromena').val()}`,
        Prezime: `${$('#prezimePromena').val()}`,
        Pol: `${$('#polPromena').val()}`,
        Jmbg: `${$('#jmbgPromena').val()}`,
        KontaktTelefon: `${$('#kontaktTelefonPromena').val()}`,
        Email: `${$('#emailPromena').val()}`,

    }

    $.ajax({
        url: '/api/musterija/',
        method: 'POST',
        data: JSON.stringify(korisnik),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (data) {
            alert("Uspesno izmenjeni podaci");
            startPocetna();
        },
        error: function (jqXHR) {
            alert(jqXHR.responseJSON["Message"]);
        }
    });

    /*$.post('/api/musterija/', $('form#musterijaPromena').serialize())
        .done(function (status, data, xhr) {
            alert(data);
            startPocetna();
        }).fail(function (jqXHR, textStatus) {
            alert(jqXHR.responseJSON["Message"]);
        });*/
}

function promenaVozaca() {

    let korisnik = {
        KorisnickoIme: `${$('#korisnickoImePromenaVozac').val()}`,
        Lozinka: `${$('#lozinkaPromenaVozac').val()}`,
        Ime: `${$('#imePromenaVozac').val()}`,
        Prezime: `${$('#prezimePromenaVozac').val()}`,
        Pol: `${$('#polPromenaVozac').val()}`,
        Jmbg: `${$('#jmbgPromenaVozac').val()}`,
        KontaktTelefon: `${$('#kontaktTelefonPromenaVozac').val()}`,
        Email: `${$('#emailPromenaVozac').val()}`,

    }

    $.ajax({
        url: '/api/vozac/',
        method: 'POST',
        data: JSON.stringify(korisnik),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (data) {
            alert("Uspesno izmenjeni podaci vozaca");
            startVozac();
        },
        error: function (jqXHR) {
            alert(jqXHR.responseJSON["Message"]);
        }
    });

    /*$.post('/api/vozac/', $('form#promeniVozaca').serialize())
        .done(function (status, data, xhr) {
            alert(data);
            startVozac();
        }).fail(function (jqXHR, textStatus) {
            alert(jqXHR.responseJSON["Message"]);
        });*/
}

function kreirajVozacaFunkcija() {

    let korisnik = {
        KorisnickoIme: `${$('#korisnickoIme2').val()}`,
        Lozinka: `${$('#lozinka2').val()}`,
        Ime: `${$('#ime2').val()}`,
        Prezime: `${$('#prezime2').val()}`,
        Pol: `${$('#pol2').val()}`,
        Jmbg: `${$('#jmbg2').val()}`,
        KontaktTelefon: `${$('#kontaktTelefon2').val()}`,
        Email: `${$('#email2').val()}`,

    }

    $.ajax({
        url: '/api/dispecerDodajVozaca/',
        method: 'POST',
        data: JSON.stringify(korisnik),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (data) {
            alert("Uspesno ste kreirali vozaca");
            startDispecer();
        },
        error: function (jqXHR) {
            alert(jqXHR.responseJSON["Message"]);
        }
    });

    /*$.post('/api/dispecerDodajVozaca/', $('form#kreirajVozacaId').serialize())
        .done(function (status, data, xhr) {
            alert(data);
            startDispecer();
        }).fail(function (jqXHR, textStatus) {
            alert(jqXHR.responseJSON["Message"]);
        });*/
}

function promenaDispecera() {

    let korisnik = {
        KorisnickoIme: `${$('#korisnickoImePromenaDispecer').val()}`,
        Lozinka: `${$('#lozinkaPromenaDispecer').val()}`,
        Ime: `${$('#imePromenaDispecer').val()}`,
        Prezime: `${$('#prezimePromenaDispecer').val()}`,
        Pol: `${$('#polPromenaDispecer').val()}`,
        Jmbg: `${$('#jmbgPromenaDispecer').val()}`,
        KontaktTelefon: `${$('#kontaktTelefonPromenaDispecer').val()}`,
        Email: `${$('#emailPromenaDispecer').val()}`,

    }

    $.ajax({
        url: '/api/dispecer/',
        method: 'POST',
        data: JSON.stringify(korisnik),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (data) {
            alert("Uspesno ste promenili podatke");
            startDispecer();
        },
        error: function (jqXHR) {
            alert(jqXHR.responseJSON["Message"]);
        }
    });

    /*$.post('/api/dispecer/', $('form#izmenaDispecera').serialize())
        .done(function (status, data, xhr) {
            alert(data);
            startDispecer();
        }).fail(function (jqXHR, textStatus) {
            alert(jqXHR.responseJSON["Message"]);
        });*/
}

function doLogSubmit() {
    let korisnik = {
        KorisnickoIme: `${$('#korisnickoI').val()}`,
        Lozinka: `${$('#loz').val()}`,
    }

    $.ajax({
        url: '/api/loggin/Prijava',
        method: 'POST',
        data: JSON.stringify(korisnik),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (data) {
            $("#reg").hide();
            localStorage.setItem("ulogovan", JSON.stringify(data));
            let recievedObject = JSON.parse(localStorage.getItem("ulogovan"));
            $("div#errdiv").hide();
            $("div#logDiv").hide();
            if (recievedObject.Uloga == 0) {
                startPocetna();
            }
            else if (recievedObject.Uloga == 1) {
                startDispecer();
            }
            else {
                startVozac();
            }
        },
        error: function (jqXHR) {
            $("div#errdiv").text(jqXHR.responseJSON["Message"]).show();
        }
    });

    /*$.post('/api/loggin/Prijava', $('form#loginForm').serialize())
        .done(function (data, status, xhr) {
            $("#reg").hide();
            localStorage.setItem("ulogovan", JSON.stringify(data));
            let recievedObject = JSON.parse(localStorage.getItem("ulogovan"));
            $("div#errdiv").hide();
            $("div#logDiv").hide();
            if (recievedObject.Uloga == 0) {
                startPocetna();
            }
            else if (recievedObject.Uloga == 1) {
                startDispecer();
            }
            else {
                startVozac();
            }
            
        })
        .fail(function (jqXHR) {
            $("div#errdiv").text(jqXHR.responseJSON["Message"]).show();
        });*/
}

function validateRegister() {
    $("#regForm").validate({
        rules: {
            korisnickoIme: {
                required: true,
                minlength: 4
            },
            lozinka: {
                required: true,
                minlength: 5
            },
            ime: "required",
            prezime: "required",
            email: {
                email: true
            },
            jmbg: {
                required: true,
                number: true,
                minlength: 13,
                maxlength: 13
            },
            kontaktTelefon: {
                number: true
            }
        },
        messages: {
            korisnickoIme: {
                required: "Obavezno polje",
                minlength: "Korisnicko ime mora imati minimum 4 karaktera"
            },
            lozinka: {
                required: "Obavezno polje",
                minlength: "Lozinka mora imati minimum 5 karaktera"
            },
            ime: "Obavezno polje",
            prezime: "Obavezno polje",
            email: {
                email: "Morate uneti validnu email adresu"
            },
            jmbg: {
                required: "Obavezno polje",
                number: "Morate uneti broj",
                minlength: "JMBG mora biti broj od 13 cifara",
                maxlength: "JMBG mora biti broj od 13 cifara"
            },
            kontaktTelefon: {
                number: "Morate uneti broj"
            }
        },
        submitHandler: function (form) { doRegistrationSubmit() }
    });
}

function validateLogin() {
    $("#loginForm").validate({
        rules: {
            korisnickoIme: {
                required: true,
                minlength: 4
            },
            lozinka: {
                required: true,
                minlength: 5
            }
        },
        messages: {
            korisnickoIme: {
                required: "Morate uneti ovo polje",
                minlength: "Korisnicko ime mora biti minimum 4 slova dugacak"
            },
            lozinka: {
                required: "Morate uneti ovo polje",
                minlength: "Lozinka mora biti minimum 5 slova dugacak"
            }
        },
        submitHandler: function (form) { doLogSubmit() }

    });
}

function validatePromenaDispecer() {
    $("#izmenaDispecera").validate({
        rules: {
            korisnickoIme: {
                required: true,
                minlength: 4
            },
            lozinka: {
                required: true,
                minlength: 5
            },
            ime: "required",
            prezime: "required",
            email: {
                email: true
            },
            jmbg: {
                required: true,
                number: true,
                minlength: 13,
                maxlength: 13
            },
            kontaktTelefon: {
                number: true
            }
        },
        messages: {
            korisnickoIme: {
                required: "Obavezno polje",
                minlength: "Korisnicko ime mora imati minimum 4 karaktera"
            },
            lozinka: {
                required: "Obavezno polje",
                minlength: "Lozinka mora imati minimum 5 karaktera"
            },
            ime: "Obavezno polje",
            prezime: "Obavezno polje",
            email: {
                email: "Morate uneti validnu email adresu"
            },
            jmbg: {
                required: "Obavezno polje",
                number: "Morate uneti broj",
                minlength: "JMBG mora biti broj od 13 cifara",
                maxlength: "JMBG mora biti broj od 13 cifara"
            },
            kontaktTelefon: {
                number: "Morate uneti broj"
            }
        },
        submitHandler: function (form) { promenaDispecera() }
    });
}

function validatePromena() {
    $("#musterijaPromena").validate({
        rules: {
            korisnickoIme: {
                required: true,
                minlength: 4
            },
            lozinka: {
                required: true,
                minlength: 5
            },
            ime: "required",
            prezime: "required",
            email: {
                email: true
            },
            jmbg: {
                required: true,
                number: true,
                minlength: 13,
                maxlength: 13
            },
            kontaktTelefon: {
                number: true
            }
        },
        messages: {
            korisnickoIme: {
                required: "Obavezno polje",
                minlength: "Korisnicko ime mora imati minimum 4 karaktera"
            },
            lozinka: {
                required: "Obavezno polje",
                minlength: "Lozinka mora imati minimum 5 karaktera"
            },
            ime: "Obavezno polje",
            prezime: "Obavezno polje",
            email: {
                email: "Morate uneti validnu email adresu"
            },
            jmbg: {
                required: "Obavezno polje",
                number: "Morate uneti broj",
                minlength: "JMBG mora biti broj od 13 cifara",
                maxlength: "JMBG mora biti broj od 13 cifara"
            },
            kontaktTelefon: {
                number: "Morate uneti broj"
            }
        },
        submitHandler: function (form) { promena() }
    });
}

function validatePromeniVozaca() {
    $("#promeniVozaca").validate({
        rules: {
            korisnickoIme: {
                required: true,
                minlength: 4
            },
            lozinka: {
                required: true,
                minlength: 5
            },
            ime: "required",
            prezime: "required",
            email: {
                email: true
            },
            jmbg: {
                required: true,
                number: true,
                minlength: 13,
                maxlength: 13
            },
            kontaktTelefon: {
                number: true
            }
        },
        messages: {
            korisnickoIme: {
                required: "Obavezno polje",
                minlength: "Korisnicko ime mora imati minimum 4 karaktera"
            },
            lozinka: {
                required: "Obavezno polje",
                minlength: "Lozinka mora imati minimum 5 karaktera"
            },
            ime: "Obavezno polje",
            prezime: "Obavezno polje",
            email: {
                email: "Morate uneti validnu email adresu"
            },
            jmbg: {
                required: "Obavezno polje",
                number: "Morate uneti broj",
                minlength: "JMBG mora biti broj od 13 cifara",
                maxlength: "JMBG mora biti broj od 13 cifara"
            },
            kontaktTelefon: {
                number: "Morate uneti broj"
            }
        },
        submitHandler: function (form) { promenaVozaca() }
    });
}

function kreirajVozaca() {
    $("#kreirajVozacaId").validate({
        rules: {
            korisnickoIme: {
                required: true,
                minlength: 4
            },
            lozinka: {
                required: true,
                minlength: 5
            },
            ime: "required",
            prezime: "required",
            email: {
                email: true
            },
            jmbg: {
                required: true,
                number: true,
                minlength: 13,
                maxlength: 13
            },
            kontaktTelefon: {
                number: true
            }
        },
        messages: {
            korisnickoIme: {
                required: "Obavezno polje",
                minlength: "Korisnicko ime mora imati minimum 4 karaktera"
            },
            lozinka: {
                required: "Obavezno polje",
                minlength: "Lozinka mora imati minimum 5 karaktera"
            },
            ime: "Obavezno polje",
            prezime: "Obavezno polje",
            email: {
                email: "Morate uneti validnu email adresu"
            },
            jmbg: {
                required: "Obavezno polje",
                number: "Morate uneti broj",
                minlength: "JMBG mora biti broj od 13 cifara",
                maxlength: "JMBG mora biti broj od 13 cifara"
            },
            kontaktTelefon: {
                number: "Morate uneti broj"
            }
        },
        submitHandler: function (form) { kreirajVozacaFunkcija() }
    });
}

function promeniLokacijuFunkcijaValidate() {
    $("#promenaLokacije").validate({
        rules: {
            lokacija2: {
                required: true,
                minlength: 5
            }
        },
        messages: {
            lokacija2: {
                required: "Obavezno polje",
                minlength: "Lokacija mora imati minimum 5 karaktera"
            }
        },
        submitHandler: function (form) { promeniLokacijuFunkcija() }
    });
}

function promeniLokacijuFunkcija() {

    let lokacija = {
        Lokacija2: `${$('#lokacija2').val()}`,
        KorisnickoImeVozaca: `${$('#korisnickoImeVozaca').val()}`,
        
    }

    $.ajax({
        url: '/api/vozacLokacija/',
        method: 'POST',
        data: JSON.stringify(lokacija),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (data) {
            alert("Uspesno ste promenili lokaciju");
            startVozac();
        },
        error: function (jqXHR) {
            alert(jqXHR.responseJSON["Message"]);
        }
    });


    /*$.post('/api/vozacLokacija/', $('form#promenaLokacije').serialize())
        .done(function (status, data, xhr) {
            alert(data);
            startVozac();
        }).fail(function (jqXHR, textStatus) {
            alert(jqXHR.responseJSON["Message"]);
        });*/
}

function ZahtevValidate() {
    $("#idZahtev").validate({
        rules: {
            lokacija: {
                required: true,
                minlength: 5
            }
        },
        messages: {
            lokacija: {
                required: "Obavezno polje",
                minlength: "Lokacija mora imati minimum 5 karaktera"
            }
        },
        submitHandler: function (form) { Zahtev() }
    });
}

function Zahtev() {

    /*let lokacija = {
        Lokacija: `${$('#lokacijaZahtev').val()}`,
        KorisnickoImeVozaca: `${$('#korisnickoImeVozaca').val()}`,

    }

    $.ajax({
        url: '/api/musterijaZahtev/',
        method: 'POST',
        data: JSON.stringify(lokacija),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (data) {
            alert("Uspesno izvrsena operacija");
            startPocetna();
        },
        error: function (jqXHR) {
            alert(jqXHR.responseJSON["Message"]);
        }
    });*/

    $.post('/api/musterijaZahtev/', $('form#idZahtev').serialize())
        .done(function (status, data, xhr) {
            alert(data);
            startPocetna();
        }).fail(function (jqXHR, textStatus) {
            alert(jqXHR.responseJSON["Message"]);
        });
}

function myMap() {
    var mapCanvas = document.getElementById("map");
    var myCenter = new google.maps.LatLng(45.242630873254775, 19.842914435055945);
    var mapOptions = { center: myCenter, zoom: 15 };
    var map = new google.maps.Map(mapCanvas, mapOptions);
    google.maps.event.addListener(map, 'click', function (event) {
        placeMarker(map, event.latLng);
    });
    
}

let fulAdresa = '';

function placeMarker(map, location) {
    var marker = new google.maps.Marker({
        position: location,
        map: map
    });
    var fullAdresa = displayLocation(location.lat(), location.lng());
    var delovi = fullAdresa.split(",");
    var ulicaIbroj = delovi[0];
    var grad = delovi[1];
    var drzava = delovi[2];
    fulAdresa = location.lat() + "," + location.lng() + "," + ulicaIbroj + "," + grad + "," + drzava;
    $("#lokacijaZahtev").val(fulAdresa);
    var infowindow = new google.maps.InfoWindow({
        content: 'Latitude: ' + location.lat() + '<br>Longitude: ' + location.lng() + '<br>Ulica i broj: ' + ulicaIbroj + '<br>Grad: ' + grad + '<br>Drzava: ' + drzava + '<br>=' + displayLocation(location.lat(), location.lng())
    });
    infowindow.open(map, marker);
}

function displayLocation(latitude, longitude) {
    var request = new XMLHttpRequest();
    var method = 'GET';
    var url = 'http://maps.googleapis.com/maps/api/geocode/json?latlng='
        + latitude + ',' + longitude + '&sensor=true';
    var async = false;
    var address;
    request.open(method, url, async);
    request.onreadystatechange = function () {
        if (request.readyState == 4 && request.status == 200) {
            var data = JSON.parse(request.responseText);
            address = data.results[0];
            var value = address.formatted_address.split(",");
            count = value.length;
            country = value[count - 1];
            state = value[count - 2];
            city = value[count - 3];
        }
    };
    request.send();
    return address.formatted_address;
};

var a;
var b;

function globalSet(index) {
    a = index;
}

function globalReturn() {
    return a;
}
function globalSet2(index) {
    b = index;
}

function globalReturn2() {
    return b;
}