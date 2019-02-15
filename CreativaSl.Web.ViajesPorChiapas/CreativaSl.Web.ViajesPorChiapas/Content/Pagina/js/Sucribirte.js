jQuery(document).ready(function () {
    Suscribite.init();
});
var Suscribite = function () {
    "use strict";
    var runSus = function () {
        $('#btnSuscribirse').click(function () {
            var campoEmail = $('#correoSuscribirse').val();
            if (campoEmail != '')
                sucribirse(campoEmail);
        });
        function sucribirse(campoEmail) {
            $.ajax({
                url: "/Home/Suscribirse",
                data: {
                    correoSuscribirse: campoEmail
                },
                dataType: "json",
                type: "POST",
                success: function (resultado) {
                    if (resultado == "OK") {
                        $('#msg_newsletter').text("Gracias por suscribirse").addClass("suscripcion_newsletterOK");
                        $('#correoSuscribirse').val('');
                    }
                    if (resultado == "KO") {
                        $('#msg_newsletter').text("Correo no valido").addClass("suscripcion_newsletterKO");
                    }
                }
            });
        }
    };
    return {
        init: function () {
            runSus();
        }
    };
}();


