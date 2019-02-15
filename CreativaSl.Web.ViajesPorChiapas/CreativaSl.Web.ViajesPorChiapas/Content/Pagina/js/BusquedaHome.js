jQuery(document).ready(function () {
    Busqueda.init();
});
var Busqueda = function () {
    "use strict";
    var runBusqueda = function () {
        $("#btnBuscarTour").click(function (event) {
            var idsTags = "";
            var idEstado = $('#DestinosT').val();
            var idLugar = $('#ListLugaresT').val();
            if (idEstado == "" || idLugar == "") {
                document.getElementById('TourMsj').innerHTML = "Selecciona un valor";
                $('#TourMsj').css('color', 'red');
            }
            else {
                document.getElementById('TourMsj').innerHTML = "";
                window.location.href = "/Tours/Busqueda/" + idEstado + "/?idLugars=" + idLugar + "&current=" + 1 + "&idTags=" + idsTags;
            }
            event.preventDefault();
        });
        $("#btnBuscarPaquete").click(function (event) {
            var idsTags = "";
            var idEstado = $('#Destinos').val();
            var idLugar = $('#ListLugares').val();
            if (idEstado == "" || idLugar == "") {
                document.getElementById('paqueteMsj').innerHTML = "Selecciona un valor";
                $('#paqueteMsj').css('color', 'red');
            }
            else {
                document.getElementById('TourMsj').innerHTML = "";
                window.location.href = "/Busqueda/Index/" + idEstado + "/?idLugars=" + idLugar + "&current=" + 1 + "&idTags=" + idsTags;
            }
            event.preventDefault();
        });
    };
    return {
        init: function () {
            runBusqueda();
        }
    };
}();

