$("#testimoniales-form").submit(function (event) {
    var nombre = $('#nomTestimonial').val();
    var comentario = $('#comentarioTestimonial').val();
    var imagen = document.getElementById('image-upload');
    var file = imagen.files[0];
    var expresion = /^\s*$/;
    var expresioncom = /^[^']{20,500}$/;

    var data = new FormData();
    data.append('nombre', nombre);
    data.append('comentario', comentario);
    data.append('urlimagen', file);
    if (!expresion.test(nombre)) {
        document.getElementById('nombre-test-val').innerHTML = " ";
        if (!expresion.test(comentario)&& expresioncom.test(comentario)) {
            document.getElementById('comentario-test-val').innerHTML = "";
            $.ajax({

                url: 'Admin/Testimoniales/Create',

                type: 'POST',

                contentType: false,

                data: data,

                processData: false,

                cache: false,
                beforeSend: function () {
                    var sidebar = document.querySelector('#why-choose-us');
                    var nuevoDivElemento = document.createElement("div");
                    var nuevaImagen = document.createElement('img');
                    nuevoDivElemento.setAttribute("id", "load");
                    nuevoDivElemento.setAttribute("style", "display:block;position: fixed;width:100%;height:100%;background:rgba(0,0,0,0.3);z-index:10000;top:0;");
                    nuevoDivElemento.setAttribute("class", "text-center");
                    nuevaImagen.setAttribute("src", "imagenes/load.gif");
                    nuevaImagen.setAttribute("style", "position: relative;top:45%; width:50px;height:50px;")
                    sidebar.appendChild(nuevoDivElemento);
                    nuevoDivElemento.appendChild(nuevaImagen);
                    
                },
                complete: function () {
                    $('#load').remove();
                },
                success: function () {

                    alert("La imagen se ha subido con exito");
                    $('#comentarioTestimonial').val('');
                    $('#nomTestimonial').val('');
                    $('#image-upload').val('');
                    $('.close').click();
                    $('.visualizar-imagen').removeAttr("style");
                }
            });
        }
        else {
            document.getElementById("comentario-test-val").style.color = "#ff4d4d";

            document.getElementById('comentario-test-val').innerHTML = "Introduce Un comentario con al menos 100 caracteres ";
        }
    }
    else {
        document.getElementById("nombre-test-val").style.color = "#ff4d4d";
        
        document.getElementById('nombre-test-val').innerHTML = "Introduce Un nombre valido ";
    }
    event.preventDefault();
    return false;
});

