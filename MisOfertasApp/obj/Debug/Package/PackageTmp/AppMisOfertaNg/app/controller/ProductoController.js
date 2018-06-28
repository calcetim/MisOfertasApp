app.controller('productoController', function ($http, $scope, URL_SERVICIOS) {

    $('#imprimir').click(function () {
        
        var producto_id = $("#producto_id").val(); 
        var codigo_venta = $("#codigo_venta").val();
        var url_final = "InprimirCuponDescuento";

        window.open(url_final + "?id=" + producto_id + "&codigo_venta=" + codigo_venta);


    });


    $('#example').barrating({
        theme: 'bootstrap-stars',
        showSelectedRating: false,
        readonly: true,
        initialRating: currentRating,
        onSelect: function (value, text) {

            if (!value) {
                //  $('#example').barrating('clear');
            } else {

                /*ENVIAR PARAMETRO DE CALIFICACION*/
                valor = $scope.form;
                /*console.log(valor);*/

                var listaDatos = {
                    "codigo_venta": valor.codigo_venta,
                    "valoracion": value,
                    "producto_id": valor.producto_id
             

                };

                console.log(listaDatos +"-->");

                $http({
                    method: 'POST',
                    url: URL_SERVICIOS.BASE_URL + 'Home/GuardarValoracionProducto',
                    data: angular.toJson(listaDatos)
                }).then(function (response) {
                    //window.location.href = response.data.Url;

                    $("#codigo_venta").val(valor.codigo_venta);

                    $("#myModal").modal("show");
                    $('#example').barrating('readonly', true);
                })
                    .catch(function (response) {

                    })
                /*FIN*/
                $('.stars-example-bootstrap .current-rating').addClass('hidden');
                $('.stars-example-bootstrap .your-rating').removeClass('hidden').find('span').html(value);
                //                alert('Selected rating: ' + value);
            }
        },
        onClear: function (value, text) {
            $('.stars-example-bootstrap')
                .find('.current-rating')
                .removeClass('hidden')
                .end()
                .find('.your-rating')
                .addClass('hidden');
        }
    });

    var currentRating = $('#example').data('current-rating');


    $('.stars-example-bootstrap .current-rating')
        .find('span')
        .html(currentRating);


    $scope.myFunc = function () {
        $scope.count++;
    };


    ///*GENERA DOCUMENTO*/

    //$scope.generarDocumento = function () {

    //    valor = $scope.form;
    //    console.log(valor);

    //    var listaDatos = {
    //        "codigo_venta": valor.codigo_venta,
    //        "id": valor.producto_id


    //    };

    //    $http({
    //        method: 'POST',
    //        url: URL_SERVICIOS.BASE_URL + 'Home/InprimirCuponDescuento',
    //        //url: '@Url.Action("InprimirCuponDescuento", "Home", new { id = "id", shopdoccode = "shopdoccode", regdate = "regdate" })',
    //        data: angular.toJson(listaDatos)
    //    }).then(function (response) {


    //        //var ruta_producto = '@Url.Action("InprimirCuponDescuento", "Home", new { id = "js-id" , codigo_venta =  \"codigo_venta_js" })'.replace("js-id", encodeURIComponent(valor.producto_id)).replace("codigo_venta_js", encodeURIComponent(valor.codigo_venta));
    //        console.log(response.config.url);


    //        window.location.href = response.config.url + "?id=" + valor.producto_id + "&codigo_venta=" + valor.codigo_venta;
    //        window.location.target = '_blank'; 


    //        //location.href = '@Url.Action("InprimirCuponDescuento", "Home")?id=' + valor.producto_id + '&codigo_venta=' + valor.codigo_venta;


    //        //var w = window.open();

    //        //put what controller gave in the new tab or win 
    //        //$(w.document.body).html(response.data);

    //        //location.href = response.data;
    //        //location.target = '_blank'; 
    //        //window.open(response.data, '_blank');
    //        //location.href = response.data.Url;
    //        ///window.location.href = "Home/InprimirCuponDescuento";
    //        //window.location.href = ruta_producto;

    //    })
    //    .catch(function (response) {

    //     })

    //};




    $scope.validarVentaProducto = function () {

        var nombre_formulario = '#producto-form';


        if ($(nombre_formulario).smkValidate()) {

            $scope.enviarFormularioProductoDetalle = function () {


                valor = $scope.form;
                console.log(valor);


                var listaDatos = {
                    "codigo_venta": valor.codigo_venta
                };

                console.log(listaDatos);

                $http({
                    method: 'POST',
                    url: URL_SERVICIOS.BASE_URL + 'Home/ValorarProducto',
                    data: angular.toJson(listaDatos)
                }).then(function (response) {

                    console.log(response);

                    if (response.data === "OK") {
                        $('#example').barrating('readonly', false);
                        $("#myModalValidado").modal("show");
                        $('#codigo_venta').attr('readonly', true);
                        $('#validar_compra').attr('disabled', true);
                    }
                    else if (response.data === "VALORACION_REALIZADA") {
                        $("#myModalRealizada").modal("show");
                    }
                    else {
                        $("#myModalError").modal("show");

                    }



                })
                    .catch(function (response) {
                        //SE ENVIA MENSAJE  DE GRABACION INCORRECTA

                        //window.location.href = response.data;

                        $("#myModalError").modal("show");

                        //$(nombre_formulario).smkClear();

                    })

            }
        }

    }




});


