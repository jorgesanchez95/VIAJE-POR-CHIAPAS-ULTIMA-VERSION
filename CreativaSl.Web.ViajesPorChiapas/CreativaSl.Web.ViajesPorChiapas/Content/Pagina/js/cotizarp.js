jQuery(document).ready(function () {
    CotizarPaquete.init();
});
var CotizarPaquete = function () {
    "use strict";
    var runPaq = function () {
        var validacionLoad1 = 0;
        var validacionLoad2 = 0;
        var numeroPersonasCotizar = 0;
        var numeroAdultoCotizar = 0;
        var numeroNiños511Cotizar = 0;
        var numeroNiños14Cotizar = 0;
        $(document).ready(function () {
            $("#numeroPersonasCotizar").change(function () {
                numeroPersonasCotizar = parseInt($("#numeroPersonasCotizar").val());
                $("#numeroAdultoCotizar").empty();
                $("#numeroNiños511Cotizar").empty();
                $("#numeroNiños14Cotizar").empty();
                for (var j = 0; j < (numeroPersonasCotizar + 1) ; j++) {
                    $('#numeroAdultoCotizar').append($('<option>', { value: j, text: j }));
                    $('#numeroNiños511Cotizar').append($('<option>', { value: j, text: j }));
                    $('#numeroNiños14Cotizar').append($('<option>', { value: j, text: j }));
                }
                HabitacionesXPersonas();
            });
            $("#numeroAdultoCotizar").change(function () {
                NumHabitacionesMinimo();
                HabitacionesXPersonas();
            });
            function NumHabitacionesMinimo() {
                var NAdultoCotizar = parseInt($("#numeroAdultoCotizar").val());
                var NNiños511Cotizar = parseInt($("#numeroNiños511Cotizar").val());
                var numHabitaciónIgnorar = float2int((((NAdultoCotizar + NNiños511Cotizar) - 1) / 4));
                $("#numeroHabitacionesCotizar").empty();
                for (var j = 1; j <= 15 ; j++) {
                    if (j <= numHabitaciónIgnorar) {
                        $('#numeroHabitacionesCotizar').append($('<option>', { value: j, text: j, disabled: true }));
                    }
                    else
                        $('#numeroHabitacionesCotizar').append($('<option>', { value: j, text: j }));
                }
                $("#numeroHabitacionesCotizar").trigger("change");
            }
            $("#numeroNiños511Cotizar").change(function () {
                NumHabitacionesMinimo();
                HabitacionesXPersonas();
            });
            $("#numeroNiños14Cotizar").change(function () {
                HabitacionesXPersonas();
            });
            $("#numeroHabitacionesCotizar").change(function () {
                $("#tabla_habitacion_cama tbody").empty();
                var numCamas = parseInt($("#numeroHabitacionesCotizar").val());
                for (var j = 1; j <= (numCamas) ; j++) {
                    $("#tabla_habitacion_cama tbody").append("<tr><td style='width:4%;font-size: 25px;align-items: center;'>" + j + "</td><td style='width:24%'><select name='numAdultos_tabla_td" + j + "' class='form-control' id='numAdultos_tabla_td" + j + "'><option value='0' selected>0</option><option value='1'>1</option><option value='2'>2</option><option value='3'>3</option><option value='4'>4</option></select></td><td style='width:24%'><select name='numNinosMenores11_tabla_td" + j + "' class='form-control' id='numNinosMenores11_tabla_td" + j + "'><option value='0' selected>0</option><option value='1' >1</option><option value='2'>2</option><option value='3'>3</option><option value='4'>4</option></select></td><td style='width:24%'><select name='numNinosMenores4_tabla_td" + j + "' class='form-control' id='numNinosMenores4_tabla_td" + j + "'><option value='0' selected>0</option><option value='1'>1</option><option value='2'>2</option><option value='3'>3</option><option value='4'>4</option></select></td><td style='width:24%'><select name='numCamas_tabla_td" + j + "' class='form-control' id='numCamas_tabla_td" + j + "'><option value='1' selected>1</option><option value='2'>2</option></select></td></tr>");
                }
                for (var j = 1; j <= (numCamas) ; j++) {
                    $("#numAdultos_tabla_td" + j).change(function () {
                        HabitacionesXPersonas();
                    });
                    $("#numNinosMenores11_tabla_td" + j).change(function () {
                        HabitacionesXPersonas();
                    });
                    $("#numNinosMenores4_tabla_td" + j).change(function () {
                        HabitacionesXPersonas();
                    });
                }
                HabitacionesXPersonas();
            });
            function float2int(value) {
                return value | 0;
            }
            function HabitacionesXPersonas() {
                var ValidacionWill = 0;
                numeroPersonasCotizar = parseInt($("#numeroPersonasCotizar").val());
                numeroAdultoCotizar = parseInt($("#numeroAdultoCotizar").val());
                numeroNiños511Cotizar = parseInt($("#numeroNiños511Cotizar").val());
                numeroNiños14Cotizar = parseInt($("#numeroNiños14Cotizar").val());
                var numeroPersonasTablaCotizar = 0;
                var numeroAdultos_TablaCotizar = 0;
                var numeroNinosMenores11TablaCotizar = 0;
                var numeroNinosMenores4TablaCotizar = 0;
                var numCamaSobrante = 0;
                var numCamas = parseInt($("#numeroHabitacionesCotizar").val());
                for (var j = 1; j <= (numCamas) ; j++) {
                    numeroAdultos_TablaCotizar = numeroAdultos_TablaCotizar + parseInt($("#numAdultos_tabla_td" + j).val());
                    numeroNinosMenores11TablaCotizar = numeroNinosMenores11TablaCotizar + parseInt($("#numNinosMenores11_tabla_td" + j).val());
                    numeroNinosMenores4TablaCotizar = numeroNinosMenores4TablaCotizar + parseInt($("#numNinosMenores4_tabla_td" + j).val());
                    if ((parseInt($("#numAdultos_tabla_td" + j).val()) + parseInt($("#numNinosMenores11_tabla_td" + j).val()) + parseInt($("#numNinosMenores4_tabla_td" + j).val())) > 0)
                        numCamaSobrante = numCamaSobrante + 1;
                    if (parseInt($("#numAdultos_tabla_td" + j).val()) + parseInt($("#numNinosMenores11_tabla_td" + j).val()) > 4) {
                        ValidacionWill = 10;
                        $("#estatus_numpersonasTabla").css('background-color', 'orange');
                        $("#estatus_numpersonasTabla").css('color', 'white');
                        $("#estatus_numpersonasTabla").text('@Html.Raw(locale.GetResourceCotizar("validacionWill01"))');
                    }
                    else
                        if ((parseInt($("#numAdultos_tabla_td" + j).val()) + parseInt($("#numNinosMenores11_tabla_td" + j).val()) + parseInt($("#numNinosMenores4_tabla_td" + j).val())) > 5) {
                            ValidacionWill = 15;
                            $("#estatus_numpersonasTabla").css('background-color', 'orange');
                            $("#estatus_numpersonasTabla").css('color', 'white');
                            $("#estatus_numpersonasTabla").text('@Html.Raw(locale.GetResourceCotizar("validacionWill01"))');
                        }
                }
                if (ValidacionWill == 0) {
                    if (numeroPersonasCotizar > (numeroAdultoCotizar + numeroNiños511Cotizar + numeroNiños14Cotizar)) {
                        if (validacionLoad1 < 2) {
                            $("#estatus_numpersonas").css('background-color', 'orange');
                            $("#estatus_numpersonas").css('color', 'white');
                            $("#estatus_numpersonas").text('@Html.Raw(locale.GetResourceCotizar("validacionLoad1"))');
                            validacionLoad1 = validacionLoad1 + 1;
                        }
                        else {
                            $("#estatus_numpersonas").css('background-color', 'red');
                            $("#estatus_numpersonas").css('color', 'white');
                            $("#estatus_numpersonas").text('@Html.Raw(locale.GetResourceCotizar("numeroPersonaMenorSolicitada"))');
                        }
                    }
                    else if (numeroPersonasCotizar < (numeroAdultoCotizar + numeroNiños511Cotizar + numeroNiños14Cotizar)) {
                        if (validacionLoad1 < 2) {
                            $("#estatus_numpersonas").css('background-color', 'orange');
                            $("#estatus_numpersonas").css('color', 'white');
                            $("#estatus_numpersonas").text('@Html.Raw(locale.GetResourceCotizar("validacionLoad1"))');
                        }
                        else {
                            $("#estatus_numpersonas").css('background-color', 'red');
                            $("#estatus_numpersonas").css('color', 'white');
                            $("#estatus_numpersonas").text('@Html.Raw(locale.GetResourceCotizar("numeroPersonaMayorSolicitada"))');
                        }
                    }
                    else {
                        $("#estatus_numpersonas").css('background-color', 'green');
                        $("#estatus_numpersonas").css('color', 'white');
                        $("#estatus_numpersonas").text('@Html.Raw(locale.GetResourceCotizar("numeroPersonasCorrectas"))');
                    }
                    if (numeroAdultoCotizar > (numeroAdultos_TablaCotizar)) {
                        if (validacionLoad2 < 2) {
                            $("#estatus_numpersonasTabla").css('background-color', 'orange');
                            $("#estatus_numpersonasTabla").css('color', 'white');
                            $("#estatus_numpersonasTabla").text('@Html.Raw(locale.GetResourceCotizar("validacionLoad2"))');
                            validacionLoad2 = validacionLoad2 + 1;
                        }
                        else {
                            $("#estatus_numpersonasTabla").css('background-color', 'red');
                            $("#estatus_numpersonasTabla").css('color', 'white');
                            $("#estatus_numpersonasTabla").text('@Html.Raw(locale.GetResourceCotizar("numeroPersonasAdultasAsignadaMenosSolicitada"))');
                        }
                    }
                    else if (numeroAdultoCotizar < (numeroAdultos_TablaCotizar)) {
                        if (validacionLoad2 < 2) {
                            $("#estatus_numpersonasTabla").css('background-color', 'orange');
                            $("#estatus_numpersonasTabla").css('color', 'white');
                            $("#estatus_numpersonasTabla").text('@Html.Raw(locale.GetResourceCotizar("validacionLoad2"))');
                            validacionLoad2 = validacionLoad2 + 1;
                        }
                        else {
                            $("#estatus_numpersonasTabla").css('background-color', 'red');
                            $("#estatus_numpersonasTabla").css('color', 'white');
                            $("#estatus_numpersonasTabla").text('@Html.Raw(locale.GetResourceCotizar("numeroPersonasAdultasAsignadaMayorSolicitada"))');
                        }
                    }
                    else if (numeroNiños511Cotizar > (numeroNinosMenores11TablaCotizar)) {
                        if (validacionLoad2 < 2) {
                            $("#estatus_numpersonasTabla").css('background-color', 'orange');
                            $("#estatus_numpersonasTabla").css('color', 'white');
                            $("#estatus_numpersonasTabla").text('@Html.Raw(locale.GetResourceCotizar("validacionLoad2"))');
                            validacionLoad2 = validacionLoad2 + 1;
                        }
                        else {
                            $("#estatus_numpersonasTabla").css('background-color', 'red');
                            $("#estatus_numpersonasTabla").css('color', 'white');
                            $("#estatus_numpersonasTabla").text('@Html.Raw(locale.GetResourceCotizar("numeroNiño51AsignadaMenorSolicitada"))');
                        }
                    }
                    else if (numeroNiños511Cotizar < (numeroNinosMenores11TablaCotizar)) {
                        if (validacionLoad2 < 2) {
                            $("#estatus_numpersonasTabla").css('background-color', 'orange');
                            $("#estatus_numpersonasTabla").css('color', 'white');
                            $("#estatus_numpersonasTabla").text('@Html.Raw(locale.GetResourceCotizar("validacionLoad2"))');
                            validacionLoad2 = validacionLoad2 + 1;
                        }
                        else {
                            $("#estatus_numpersonasTabla").css('background-color', 'red');
                            $("#estatus_numpersonasTabla").css('color', 'white');
                            $("#estatus_numpersonasTabla").text('@Html.Raw(locale.GetResourceCotizar("numeroNiño51AsignadaMayorSolicitada"))');
                        }
                    }
                    else if (numeroNiños14Cotizar > (numeroNinosMenores4TablaCotizar)) {
                        if (validacionLoad2 < 2) {
                            $("#estatus_numpersonasTabla").css('background-color', 'orange');
                            $("#estatus_numpersonasTabla").css('color', 'white');
                            $("#estatus_numpersonasTabla").text('@Html.Raw(locale.GetResourceCotizar("validacionLoad2"))');
                            validacionLoad2 = validacionLoad2 + 1;
                        }
                        else {
                            $("#estatus_numpersonasTabla").css('background-color', 'red');
                            $("#estatus_numpersonasTabla").css('color', 'white');
                            $("#estatus_numpersonasTabla").text('@Html.Raw(locale.GetResourceCotizar("numeroNiño14AsignadaMenorSolicitada"))');
                        }
                    }
                    else if (numeroNiños14Cotizar < (numeroNinosMenores4TablaCotizar)) {
                        if (validacionLoad2 < 2) {
                            $("#estatus_numpersonasTabla").css('background-color', 'orange');
                            $("#estatus_numpersonasTabla").css('color', 'white');
                            $("#estatus_numpersonasTabla").text('@Html.Raw(locale.GetResourceCotizar("validacionLoad2"))');
                            validacionLoad2 = validacionLoad2 + 1;
                        }
                        else {
                            $("#estatus_numpersonasTabla").css('background-color', 'red');
                            $("#estatus_numpersonasTabla").css('color', 'white');
                            $("#estatus_numpersonasTabla").text('@Html.Raw(locale.GetResourceCotizar("numeroNiño14AsignadaMayorSolicitada"))');
                        }
                    }
                    else if (numCamas > (numCamaSobrante)) {
                        if (validacionLoad2 < 2) {
                            $("#estatus_numpersonasTabla").css('background-color', 'orange');
                            $("#estatus_numpersonasTabla").css('color', 'white');
                            $("#estatus_numpersonasTabla").text('@Html.Raw(locale.GetResourceCotizar("validacionLoad2"))');
                            validacionLoad2 = validacionLoad2 + 1;
                        }
                        else {
                            $("#estatus_numpersonasTabla").css('background-color', 'red');
                            $("#estatus_numpersonasTabla").css('color', 'white');
                            $("#estatus_numpersonasTabla").text('@Html.Raw(locale.GetResourceCotizar("numeroCamaAsignadaMenorSolicitada"))');
                        }
                    }
                    else if (numCamas < (numCamaSobrante)) {
                        if (validacionLoad2 < 2) {
                            $("#estatus_numpersonasTabla").css('background-color', 'orange');
                            $("#estatus_numpersonasTabla").css('color', 'white');
                            $("#estatus_numpersonasTabla").text('@Html.Raw(locale.GetResourceCotizar("validacionLoad2"))');
                            validacionLoad2 = validacionLoad2 + 1;
                        }
                        else {
                            $("#estatus_numpersonasTabla").css('background-color', 'red');
                            $("#estatus_numpersonasTabla").css('color', 'white');
                            $("#estatus_numpersonasTabla").text('@Html.Raw(locale.GetResourceCotizar("numeroCamaAsignadaMayorSolicitada"))');
                        }
                    }
                    else {
                        $("#estatus_numpersonasTabla").css('background-color', 'green');
                        $("#estatus_numpersonasTabla").css('color', 'white');
                        $("#estatus_numpersonasTabla").text('@Html.Raw(locale.GetResourceCotizar("numeroPersonaAsignadaCorrectamente"))');
                    }
                }
            }
            $("#form_paquetes").submit(function (e) {
                var banValidacion1 = 0;
                var banValidacion2 = 0;
                var banValidacionWill = 0;
                numeroPersonasCotizar = parseInt($("#numeroPersonasCotizar").val());
                numeroAdultoCotizar = parseInt($("#numeroAdultoCotizar").val());
                numeroNiños511Cotizar = parseInt($("#numeroNiños511Cotizar").val());
                numeroNiños14Cotizar = parseInt($("#numeroNiños14Cotizar").val());
                var numeroPersonasTablaCotizar = 0;
                var numeroAdultos_TablaCotizar = 0;
                var numeroNinosMenores11TablaCotizar = 0;
                var numeroNinosMenores4TablaCotizar = 0;
                var numCamaSobrante = 0;
                var numCamas = parseInt($("#numeroHabitacionesCotizar").val());
                for (var j = 1; j <= (numCamas) ; j++) {
                    numeroAdultos_TablaCotizar = numeroAdultos_TablaCotizar + parseInt($("#numAdultos_tabla_td" + j).val());
                    numeroNinosMenores11TablaCotizar = numeroNinosMenores11TablaCotizar + parseInt($("#numNinosMenores11_tabla_td" + j).val());
                    numeroNinosMenores4TablaCotizar = numeroNinosMenores4TablaCotizar + parseInt($("#numNinosMenores4_tabla_td" + j).val());
                    if ((parseInt($("#numAdultos_tabla_td" + j).val()) + parseInt($("#numNinosMenores11_tabla_td" + j).val()) + parseInt($("#numNinosMenores4_tabla_td" + j).val())) > 0)
                        numCamaSobrante = numCamaSobrante + 1;
                    if ((parseInt($("#numAdultos_tabla_td" + j).val()) + parseInt($("#numNinosMenores11_tabla_td" + j).val())) > 4) {
                        banValidacionWill = 10;
                        $("#estatus_numpersonasTabla").css('background-color', 'orange');
                        $("#estatus_numpersonasTabla").css('color', 'white');
                        $("#estatus_numpersonasTabla").text('@Html.Raw(locale.GetResourceCotizar("validacionWill01"))');
                    }
                    else
                        if ((parseInt($("#numAdultos_tabla_td" + j).val()) + parseInt($("#numNinosMenores11_tabla_td" + j).val()) + parseInt($("#numNinosMenores4_tabla_td" + j).val())) > 5) {
                            banValidacionWill = 15;
                            $("#estatus_numpersonasTabla").css('background-color', 'orange');
                            $("#estatus_numpersonasTabla").css('color', 'white');
                            $("#estatus_numpersonasTabla").text('@Html.Raw(locale.GetResourceCotizar("validacionWill01"))');
                        }
                }
                if (banValidacionWill == 0) {
                    if (numeroPersonasCotizar > (numeroAdultoCotizar + numeroNiños511Cotizar + numeroNiños14Cotizar)) {
                        $("#estatus_numpersonas").css('background-color', 'red');
                        $("#estatus_numpersonas").css('color', 'white');
                        $("#estatus_numpersonas").text('@Html.Raw(locale.GetResourceCotizar("numeroPersonasMenorSolicitada"))');
                    }
                    else if (numeroPersonasCotizar < (numeroAdultoCotizar + numeroNiños511Cotizar + numeroNiños14Cotizar)) {
                        $("#estatus_numpersonas").css('background-color', 'red');
                        $("#estatus_numpersonas").css('color', 'white');
                        $("#estatus_numpersonas").text('@Html.Raw(locale.GetResourceCotizar("numeroPersonaMayorSolicitada"))');
                    }
                    else {
                        banValidacion1 = 1;
                        $("#estatus_numpersonas").css('background-color', 'green');
                        $("#estatus_numpersonas").css('color', 'white');
                        $("#estatus_numpersonas").text('@Html.Raw(locale.GetResourceCotizar("numeroPersonasCorrectas"))');
                    }
                    if (numeroAdultoCotizar > (numeroAdultos_TablaCotizar)) {
                        $("#estatus_numpersonasTabla").css('background-color', 'red');
                        $("#estatus_numpersonas").css('color', 'white');
                        $("#estatus_numpersonasTabla").text('@Html.Raw(locale.GetResourceCotizar("numeroPersonasAdultasAsignadaMenosSolicitada"))');
                    }
                    else if (numeroAdultoCotizar < (numeroAdultos_TablaCotizar)) {
                        $("#estatus_numpersonasTabla").css('background-color', 'red');
                        $("#estatus_numpersonas").css('color', 'white');
                        $("#estatus_numpersonasTabla").text('@Html.Raw(locale.GetResourceCotizar("numeroPersonasAdultasAsignadaMayorSolicitada"))');
                    }
                    else if (numeroNiños511Cotizar > (numeroNinosMenores11TablaCotizar)) {
                        $("#estatus_numpersonasTabla").css('background-color', 'red');
                        $("#estatus_numpersonas").css('color', 'white');
                        $("#estatus_numpersonasTabla").text('@Html.Raw(locale.GetResourceCotizar("numeroNiño51AsignadaMenorSolicitada"))');
                    }
                    else if (numeroNiños511Cotizar < (numeroNinosMenores11TablaCotizar)) {
                        $("#estatus_numpersonasTabla").css('background-color', 'red');
                        $("#estatus_numpersonas").css('color', 'white');
                        $("#estatus_numpersonasTabla").text('@Html.Raw(locale.GetResourceCotizar("numeroNiño51AsignadaMayorSolicitada"))');
                    }
                    else if (numeroNiños14Cotizar > (numeroNinosMenores4TablaCotizar)) {
                        $("#estatus_numpersonasTabla").css('background-color', 'red');
                        $("#estatus_numpersonas").css('color', 'white');
                        $("#estatus_numpersonasTabla").text('@Html.Raw(locale.GetResourceCotizar("numeroNiño14AsignadaMenorSolicitada"))');
                    }
                    else if (numeroNiños14Cotizar < (numeroNinosMenores4TablaCotizar)) {
                        $("#estatus_numpersonasTabla").css('background-color', 'red');
                        $("#estatus_numpersonas").css('color', 'white');
                        $("#estatus_numpersonasTabla").text('@Html.Raw(locale.GetResourceCotizar("numeroNiño14AsignadaMayorSolicitada"))');
                    }
                    else if (numCamas > (numCamaSobrante)) {
                        $("#estatus_numpersonasTabla").css('background-color', 'red');
                        $("#estatus_numpersonas").css('color', 'white');
                        $("#estatus_numpersonasTabla").text('@Html.Raw(locale.GetResourceCotizar("numeroCamaAsignadaMenorSolicitada"))');
                    }
                    else if (numCamas < (numCamaSobrante)) {
                        $("#estatus_numpersonasTabla").css('background-color', 'red');
                        $("#estatus_numpersonas").css('color', 'white');
                        $("#estatus_numpersonasTabla").text('@Html.Raw(locale.GetResourceCotizar("numeroCamaAsignadaMayorSolicitada"))');
                    }
                    else {
                        banValidacion2 = 1;
                        $("#estatus_numpersonasTabla").css('background-color', 'green');
                        $("#estatus_numpersonas").css('color', 'white');
                        $("#estatus_numpersonasTabla").text('@Html.Raw(locale.GetResourceCotizar("numeroPersonaAsignadaCorrectamente"))');
                    }
                }
                if (banValidacion1 == 1 && banValidacion2 == 1 && banValidacionWill == 0) {
                    return true;
                }
                else {
                    return false;
                }
            });
            $("#BoletoCotizar").change(function () {
                var aux = 0;
                aux = $("#BoletoCotizar").val();
                if (aux == "true") {
                    $('#aeropuertollegada_div').show();
                    $('#aeropuertosalida_div').show();
                    $('#horallegada_div').show();
                    $('#horasalida_div').show();
                }
                else {
                    $('#aeropuertollegada_div').hide();
                    $('#aeropuertosalida_div').hide();
                    $('#horallegada_div').hide();
                    $('#horasalida_div').hide();
                }
            });
            $("#numeroPersonasCotizar").val = "1";
            $("#numeroPersonasCotizar").trigger("change");
            $("#numeroHabitacionesCotizar").trigger("change");
            $("#BoletoCotizar").trigger("change");
        });
        $(document).ready(function () {
            jQuery.validator.methods["date"] = function (value, element) { return true; }
        });
    };
    return {
        init: function () {
            runPaq();
        }
    };
}();


