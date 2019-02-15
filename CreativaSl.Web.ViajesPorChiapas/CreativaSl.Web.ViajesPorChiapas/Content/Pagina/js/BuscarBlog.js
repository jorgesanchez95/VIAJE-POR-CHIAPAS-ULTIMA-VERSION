var BuscarBlog = function () {
    "use strict";
    var runBlog = function () {
            $(".btnFiltrar").click(function (event) {
                var idsTags = "";
                idsTags = this.id
                window.location.href = "/Blog/Index/?current=1" + "&idTags=" + idsTags;
                event.preventDefault();
            });
    };
    return {
        init: function () {
            runBlog();
        }
    };
}();