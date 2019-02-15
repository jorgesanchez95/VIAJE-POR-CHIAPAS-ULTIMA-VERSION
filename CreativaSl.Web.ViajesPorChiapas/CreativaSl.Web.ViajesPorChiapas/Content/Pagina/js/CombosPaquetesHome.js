jQuery(document).ready(function () {
    CmbPaquete.init();
});
var CmbPaquete = function () {
    "use strict";
    var runCmbP = function () {
        $("#Destinos").change(function () {
            var id = $("#Destinos").val();
            $.ajax({
                url: "/Home/LugaresTuristicos",
                data: { id: id },
                dataType: "json",
                type: "POST",
                error: function () {
                    $("#ListLugares").html('');
                },
                success: function (municipio) {
                    var items = "";
                    for (var i = 0; i < municipio.length; i++) {
                        items += "<option value=\"" + municipio[i].id_tipoPaquete + "\">" + municipio[i].descripcion + "</option>";
                    }
                    $("#ListLugares").html(items);
                }
            });
        });
        $("#DestinosT").change(function () {
            var id = $("#DestinosT").val();
            $.ajax({
                url: "/Home/LugaresTuristicosTours",
                data: { id: id },
                dataType: "json",
                type: "POST",
                error: function () {
                    $("#ListLugaresT").html('');
                },
                success: function (municipio) {
                    var items = "";
                    for (var i = 0; i < municipio.length; i++) {
                        items += "<option value=\"" + municipio[i].id_lugar + "\">" + municipio[i].nombre + "</option>";
                    }
                    $("#ListLugaresT").html(items);
                }
            });
        });
    };
    return {
        init: function () {
            runCmbP();
        }
    };
}();

