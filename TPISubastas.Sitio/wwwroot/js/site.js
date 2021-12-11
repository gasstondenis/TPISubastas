// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function genenarHtmlEnString(data) {
    var nuevocontenido = '';
    for (var i = 0; i < data.subastas.length; i++) {
        var item = data.subastas[i];
        nuevocontenido += '<li><div><a href="/Subasta/DetalleSubasta?IdSubasta=' + item.IdSubasta + '">' + item.nombre + '</a><p>desde ' + item.fechaInicio + ' Hasta ' + item.fechaCierre + '</p></div></li >';
    }

    $('#listaSubastas').html(nuevocontenido);
}
function generarHtmlConObjetos(data) {
    $('#listaSubastas').html('');
    for (var i = 0; i < data.subastas.length; i++) {
        var item = data.subastas[i];
        var tarjeta = $('<li/>');
        var cuerpo = $('<div/>');
        var titulo = $('<a/>');
        var pie = $('<div/>');
        var imagen = $('<img/>');
        var descripcion = $('<p/>');
        descripcion.html(item.descripcion);
        descripcion.addClass('card-text');

        imagen.prop('src', './img/subastas.jpg');
        imagen.addClass('card-img-top');
        tarjeta.append(imagen);

        titulo.prop('href', '/Subasta/DetalleSubasta?IdSubasta=' + item.idSubasta);
        titulo.html(item.nombre);
        titulo.addClass('card-title');

        cuerpo.append(titulo);

        pie.html('Valido desde ' + item.fechaInicioStr + ' hasta ' + item.fechaCierreStr);
        pie.addClass('card-footer');


        //$('<li/>').append(ditem).appendTo('#listaSubastas');
        cuerpo.addClass('card-body');
        cuerpo.append(descripcion);
        tarjeta.append(cuerpo);
        tarjeta.addClass('card');
        tarjeta.append(pie);
        $('#listaSubastas').append(tarjeta);
    }
}
function mostrarPaginas(data) {
    $('#subastasPaginas').html('');
    for (var i = -1; i < data.totalPaginas + 1; i++) {
        var litem = $('<li/>');
        litem.addClass('page-item');
        var contenido = '';
        if (i == -1) {
            if (data.pagina == 1) {
                litem.addClass('disabled');
                contenido = '<span class="page-link">Anterior</span>';
            }
            else {
                contenido = '<a class="page-link" href="#" onclick="cargarSubastas(' + (data.pagina - 1) + ',' + data.Cantidad + ')">Anterior</a>';
            }
        }
        else if (i == data.totalPaginas) {
            if (data.pagina == data.totalPaginas) {
                litem.addClass('disabled');
                contenido = '<span class="page-link">Siguiente</span>';
            }
            else {
                contenido = '<a class="page-link" href="#" onclick="cargarSubastas(' + (data.pagina + 1) + ',' + data.Cantidad + ')">Siguiente</a>';
            }
        }
        else if (i + 1 == data.pagina) {
            litem.addClass('active');
            contenido = '<span class="page-link">' + (i + 1) + '</span>';
        }
        else {
            contenido = '<a class="page-link" href="#" onclick="cargarSubastas(' + (i + 1) + ',' + data.Cantidad + ')">' + (i + 1) + '</a>';
        }
        litem.html(contenido);
        $('#subastasPaginas').append(litem);
    }
}
function cargarSubastas(pagina, cantidad) {
    $.ajax({
        url: "/SubastaAjax/ListarSubastas",
        method: "POST",
        data: {
            pagina: pagina,
            cantidad: cantidad
        },
        dataType: "json",
        success: function (data) {
            //genenarHtmlEnString(data);
            generarHtmlConObjetos(data);
            mostrarPaginas(data);
        },
        error: function (error) {
            alert(error);
        },
    });
}