app.controller('publicarController', function ($http, $scope, URL_SERVICIOS) {



    //BUSCA TIENDAS 
    $http.get(URL_SERVICIOS.BASE_URL + 'Listas/getProductos').then(function (response) {
        //console.log(response.data);
        $scope.productos = response.data;
    })

    //BUSCA PRODUCTOS
    $http.get(URL_SERVICIOS.BASE_URL + 'Listas/getTiendas').then(function (response) {

        $scope.tiendas = response.data;
    })


    $scope.validateIngresoOferta = function () {

        var nombre_formulario = '#formPublicarOferta';

        if ($(nombre_formulario).smkValidate()) {

            console.log($scope.enviarFormularioIngresoOferta);
            $scope.enviarFormularioIngresoOferta = function () {

                alert("aa");
                valor = $scope.form;
                console.log("aaa");
                console.log(valor);


                var listaDatos = {
                    "oferta":
                        {
                            "STOCK": valor.stock,
                            "PRECIO": valor.precio,
                            "PRECIO_OFERTA": valor.precio_oferta,
                            "DOS_POR_UNO": valor.dos_por_uno,
                            "DETALLE": valor.detalle,
                            "PCT_DESCUENTO": valor.pct_descuento,                           
                            //"Imagen": {
                            //    "IMAGEN": valor.id
                            //},
                            "Producto": {
                                "ID_PRODUCTO": valor.producto_id
                            },
                            "Tienda": {
                                "ID_TIENDA": valor.tienda_id
                            }
                        }
                };

                console.log(listaDatos);

                $http({
                    method: 'POST',
                    url: URL_SERVICIOS.BASE_URL + 'Home/GuardarOferta',
                    data: angular.toJson(listaDatos)
                }).then(function (response) {




                    window.location.href = response.data;

                    //SE ENVIA MENSAJE  DE GRABACION CORRECTA
                    $.smkAlert({
                        text: 'El ingreso de su oferta a sido exitoso',
                        type: 'success',
                        position: 'bottom-center',
                        time: 5
                    });

                    // SE LIMPIA FORMULARIO UNA VEZ GRADO CORRECTAMENTE


                    $(nombre_formulario).smkClear();




                })
                    .catch(function (response) {
                        //SE ENVIA MENSAJE  DE GRABACION INCORRECTA

                        window.location.href = response.data;

                        $.smkAlert({
                            text: 'Error al ingresar Oferta',
                            type: 'danger',
                            position: 'bottom-center',
                            time: 5
                        });

                        $(nombre_formulario).smkClear();

                    })

            }

        }
    };
});


