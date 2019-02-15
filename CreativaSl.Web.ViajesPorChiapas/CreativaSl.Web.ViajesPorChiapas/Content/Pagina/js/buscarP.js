jQuery(document).ready(function () {
    BuscarPT.init();
});
var BuscarPT = function () {
    "use strict";
    var runPT = function () {
        $('#btnBuscarTour').click(function (event) {
            var idEstado = $('#DestinosT').val();
            var idLugar = $('#ListLugaresT').val();
            var curr = 0;
            var idTagss = "";
            var idSec = "";
            
            if (idLugar == null) {
                alert(idEstado + ", " + idLugar);
            } else {
                if (idEstado == "" || idLugar == "") {
                    alert(idEstado + ", " + idLugar);
                }
                else {
                    window.location.href = "/Busqueda/Index/" + idEstado + "/?current=1" + idLugar + "&idTags=" + idsTags;
                    alert(idEstado + ", " + idLugar);
                    //$.ajax({
                    //    url: "/Busqueda/Index",
                    //    data: {
                    //        id: idEstado,
                    //        idLugars: idLugar,
                    //        current: curr,
                    //        idTags: idTagss,
                    //        id_seccion: idSec
                    //    },
                    //    dataType: "json",
                    //    type: "POST",
                    //    success: function () {
                    //        console.log("hOLA SDASDASDASDASD");
                    //        window.location.href = "/Busqueda/Index";
                    //    }
                    //});
                }
            }




            //if (campoEmail != '')
            //    sucribirse(campoEmail);
        });
        //function sucribirse(campoEmail) {
        //    $.ajax({
        //        url: "/Home/Suscribirse",
        //        data: {
        //            correoSuscribirse: campoEmail
        //        },
        //        dataType: "json",
        //        type: "POST",
        //        success: function (resultado) {
        //            if (resultado == "OK") {
        //                $('#msg_newsletter').text("Gracias por suscribirse").addClass("suscripcion_newsletterOK");
        //                $('#correoSuscribirse').val('');
        //            }
        //            if (resultado == "KO") {
        //                $('#msg_newsletter').text("Correo no valido").addClass("suscripcion_newsletterKO");
        //            }
        //        }
        //    });
        //}
    };
    return {
        init: function () {
            runPT();
        }
    };
}();


