var currentPage = 1;
function deleteEmpresa(btn, id) {
    if (confirm("¿Está seguro que desea realizar esta acción?")) {
        $(btn).prop('disabled', true);
        $("#myGrid").html('<img class="loader" src="/assets/img/loader.gif" />');
        $.ajax({
            type: "POST",
            url: "/WebMethods.aspx/deleteEmpresa",
            data: "{'id_empresa' : '" + id + "' }",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                if (response.d) {
                    alert("La empresa se ha sido borrada.");
                } else
                    alert("Error al borrar la empresa.");
                refresh(1);
            },
            failure: function (response) {
                alert(response.d);
            }
        });
    }
}

function updateEmpresa(btn, id) {
    $(btn).prop('disabled', true);
    location.replace("frmNuevaEmpresa.aspx?id_empresa=" + id);
}

function deleteSucursal(btn, id) {
    if (confirm("¿Está seguro que desea realizar esta acción?")) {
        $(btn).prop('disabled', true);
        $("#myGrid").html('<img class="loader" src="/assets/img/loader.gif" />');
        $.ajax({
            type: "POST",
            url: "/WebMethods.aspx/deleteSucursal",
            data: "{'id_empsucursal' : '" + id + "' }",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                refresh(1);
            },
            failure: function (response) {
                alert(response.d);
            }
        });
    }
}

function updateSucursal(btn, id) {
    $(btn).prop('disabled', true);
    location.replace("frmNuevaSucursal.aspx?id_empsucursal=" + id);
}

var uri = "";
function init(link) {
    uri = link;
    $("#myGrid").html('<img class="loader" src="/assets/img/loader.gif" />');
    refresh(1);
    $("#btnSearch").click(function () {
        $("#myGrid").html('<img class="loader" src="/assets/img/loader.gif" />');
        refresh(1);
    });
    $("#textToSearch").keypress(function (e) {
        if (e.which == 13) {
            $("#btnSearch").trigger("click");
            e.preventDefault();
            return false;
        }
    });
}

function refresh(page) {
    currentPage = page;
    $.ajax({
        type: "POST",
        url: uri,
        data: "{'page':'" + page + "', 'activePage': '" + currentPage + "', 'search':'" + $("#textToSearch").val() + "' }",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            $("#myGrid").html(response.d);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Error al accesar a los datos, recargue la página o acceda más tarde.");
        }
    });
}

function prev() {
    currentPage--;
    refresh(currentPage);
}

function next() {
    currentPage++;
    refresh(currentPage);
}