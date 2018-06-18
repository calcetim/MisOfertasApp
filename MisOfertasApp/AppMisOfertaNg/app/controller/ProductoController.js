app.controller('productoController', function ($http, $scope, URL_SERVICIOS) {

    $scope.validarVentaProducto = function () {

        var nombre_formulario = '#producto-form';


        $('#star1').starrr({
            readOnly: false,
            change: function (e, value) {
                if (value) {
                    $('.your-choice-was').show();
                    $('.choice').text(value);
                } else {
                    $('.your-choice-was').hide();
                }
            }
        });

        
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

                                if (response.data === "OK")
                                {
                                    $("#myModal").modal("show");
                                    $("#codigo_venta").val("");


                                    $('#star1').starrr({
                                        readOnly: false,
                                        change: function (e, value) {
                                            if (value) {
                                                $('.your-choice-was').show();
                                                $('.choice').text(value);

                                            } else {
                                                $('.your-choice-was').hide();
                                            }
                                        }
                                    });

                                }
                                else
                                {
                                    $("#myModalError").modal("show");
                                    $('#star1').starrr({
                                        readOnly: false,
                                        change: function (e, value) {
                                            if (value) {
                                                $('.your-choice-was').show();
                                                $('.choice').text(value);
                                            } else {
                                                $('.your-choice-was').hide();
                                            }
                                        }
                                    });
                                }

                               

                            })
                            .catch(function (response) {
                                    //SE ENVIA MENSAJE  DE GRABACION INCORRECTA

                                    //window.location.href = response.data;

                                     $("#myModalError").modal("show");

                                    $(nombre_formulario).smkClear();

                                })

            }
        }

    }




});


