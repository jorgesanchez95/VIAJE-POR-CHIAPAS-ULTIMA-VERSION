jQuery(document).ready(function () {
    Contacto.init();
});
var Contacto = function () {
    "use strict";
    var runCont = function () {
        $("#form_contactar").submit(function (e) {
            var nombre = $('#nombre').val();
            var correo = $('#correo').val();
            var telefono = $('#telefono').val();
            var horarioContacto = $('#horarioContacto').val();
            var asunto = $('#asunto').val();
            var mensaje = $('#mensaje').val();
            if (nombre != '' && correo != '' && telefono != '' && horarioContacto != '' && asunto != '' && mensaje != '')
            {
                $.ajax({
                    url: "/Contactos/Contactar",
                    data: {
                        nombre: nombre,
                        correo: correo,
                        telefono: telefono,
                        horarioContacto: horarioContacto,
                        asunto: asunto,
                        mensaje: mensaje,
                    },
                    dataType: "json",
                    type: "POST",
                    success: function (resultado) {
                        if (resultado == "OK") {
                            $('#msg_gracias').text("Gracias por contactarnos en breve una de nuestros agentes le responderá");
                        }
                        if (resultado == "KO") {
                            $('#msg_gracias').text("Lo sentimos algo salio mal. Intente de nuevo más tarde");
                        }
                    }
                });
            }
            return false;
        });
    };
    return {
        init: function () {
            runCont();
        }
    };
}();