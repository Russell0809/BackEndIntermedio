var APIEndPoint = "https://ipinfo.io/json?token=f30c6f316e0d09";

function obtenerYMostrarUbicacion() {
    $.getJSON(APIEndPoint, function (DatosUbicacion) {
        console.log(DatosUbicacion);
        const latitud = DatosUbicacion.loc.split(',')[0];
        const longitud = DatosUbicacion.loc.split(',')[1];
        const city = DatosUbicacion.city;
        const ip = DatosUbicacion.ip;
        console.log(`Tus datos son ${latitud}, ${longitud}, ${city}, ${ip}`);

        //$("#ubicacion").text(`Latitud: ${latitud}, Longitud: ${longitud}, Ciudad: ${city}, IP: ${ip}`);

        $("#ubicacion").text(`Usted nos visita desde ${city}, su IP publica es:  ${ip}`);
    });
}

$(document).ready(function () {
    obtenerYMostrarUbicacion();
});