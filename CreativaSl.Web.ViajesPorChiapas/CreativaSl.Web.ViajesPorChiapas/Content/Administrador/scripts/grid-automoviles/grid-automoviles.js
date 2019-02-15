$(document).ready(function () {
    actualizarPagina();
});

$('a.delete').live('click', function (e) {
    e.preventDefault();

    if (confirm("Confirmar eliminación?") == false) return;

    var idVehiculo = $(this).attr('value');
    eliminarVehiculo(idVehiculo);
});


    function eliminarVehiculo(idAutomovil) {
        $(document).ready(function () {
            $.ajax({
                type: "POST",
                url: "gridAutomoviles.aspx/eliminarVehiculo",
                data: '{idVehiculo: "' + idAutomovil + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: actualizarPagina
            });
        });
    }


    function actualizarPagina() {
        $(document).ready(function () {
            $.ajax({
                type: "POST",
                url: "gridAutomoviles.aspx/cargarGrid",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    $("#miGrid").html(msg.d);
                    generarPaginador();
                }
            });
        });
    }

    function generarPaginador() {
        $(document).ready(function () {
            $.ajax({
                type: "POST",
                url: "gridAutomoviles.aspx/obtenerPaginas",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    $("#paginas").html(msg.d);
                }
            });
        });
    }
