app.controller('publicarController', function ($http, $scope, URL_SERVICIOS) {



    //BUSCA TIENDAS 
    $http.get(URL_SERVICIOS.BASE_URL + 'Listas/getProductos').then(function (response) {
        //console.log(response.data);
        $scope.productos = response.data;
    });

    //BUSCA PRODUCTOS
    $http.get(URL_SERVICIOS.BASE_URL + 'Listas/getTiendas').then(function (response) {
        $scope.tiendas = response.data;
        console.log($scope.tiendas[1]);
        $scope.form.tienda_id = $scope.tiendas[1];


    });


    $('#txtUploadFile').on('change', function (e) {

        $scope.archivos = e.target.files;

    });



    $table = $('table#table_publicar_oferta').DataTable();


    $('#table_publicar_oferta').on('click', '.editor_delete', function () {

        var closestRow = $(this).closest('tr');
        var data = $table.row(closestRow).data();
        var oferta_id = data[7];

        console.log(oferta_id);

        var listaDatos = {
            "oferta_id": oferta_id
        };


        $http({
            method: 'POST',
            url: URL_SERVICIOS.BASE_URL + 'Home/eliminarPublicacion',
            data: angular.toJson(listaDatos)

        }).then(function (response) {




            $scope.form = response.data;

            location.reload();

            console.log($scope.producto_test);

        })
            .catch(function (response) {

            });
    });



    $('#table_publicar_oferta').on('click', '.editor_edit', function () {

        var closestRow = $(this).closest('tr');
        var data = $table.row(closestRow).data();
        var oferta_id = data[6];

        console.log(oferta_id);

        var listaDatos = {
            "oferta_id": oferta_id
        };


        $http({
            method: 'POST',
            url: URL_SERVICIOS.BASE_URL + 'Home/editarPublicacion',
            data: angular.toJson(listaDatos)

        }).then(function (response) {




            $scope.form = response.data;



            console.log($scope.producto_test);

        })
            .catch(function (response) {

            });
    });

  

    //$table = $('#table_publicar_oferta').DataTable();
    //$('#table_publicar_oferta tbody').on('click', 'td button', function () {



    //    var data = table.row($(this).parents('tr')).data();

    //    alert(data[0]);

    //    //$table = $('table#summary').DataTable();
    //    //var data = $table.row(this).data();
    //    //var taskID = data[0];
    //    //alert(taskID);
        
    //});

    $scope.validateIngresoOferta = function () {

        var nombre_formulario = '#formPublicarOferta';

       

        if ($(nombre_formulario).smkValidate()) {

            console.log("validado");


            
            $scope.enviarFormularioIngresoOferta = function () {

                var valor;

                if (angular.isObject($scope.form))
                {

                     valor = $scope.form;
                    console.log("form");

                } else
                {

                     valor = $scope.producto_test;
                    console.log("test");
                }


                var val = angular.element(jQuery('#PCT_DESCUENTO')).triggerHandler('input');


                console.log(val);

                console.log($scope.form);

                var listaDatos = {
                    "STOCK": valor.STOCK,
                    "PRECIO": valor.PRECIO,
                    "PRECIO_OFERTA": valor.PRECIO_OFERTA,
                    "DOS_POR_UNO": valor.DOS_POR_UNO,
                    "DETALLE": valor.DETALLE,
                    "PCT_DESCUENTO": valor.PCT_DESCUENTO,
                    "ID_OFERTA": valor.ID_OFERTA,
                    "Producto": {
                        "ID_PRODUCTO": valor.ID_PRODUCTO
                            },
                    "Tienda": {
                        "ID_TIENDA": valor.ID_TIENDA
                            }
                };


                


                if (valor.ID_IMAGEN > 0 ) {

                    listaDatos.Imagen = {

                        "ID_IMAGEN": valor.ID_IMAGEN
                    };

                }


                console.log(listaDatos);


                $http({
                    method: 'POST',
                    url: URL_SERVICIOS.BASE_URL + 'Home/GuardarOferta',
                    headers: { 'Content-Type': undefined },
                    transformRequest: function (data) {
                        var formData = new FormData();
                        formData.append("jsonData", angular.toJson(listaDatos));



                        if (angular.isObject($scope.archivos)) {

                            for (var i = 0; i < $scope.archivos.length; i++) {
                                formData.append("archivo_consulta_" + i, $scope.archivos[i]);
                            }
                        }
                        

                        return formData;
                    },
                    data: { jsonData: $scope.jsonData, files: $scope.archivos }
                }).then(function (response) {

                    //SE ENVIA MENSAJE  DE GRABACION CORRECTA
                    $.smkAlert({
                        text: 'El ingreso de su oferta a sido exitoso',
                        type: 'success',
                        position: 'bottom-center',
                        time: 5
                    });

        

                    $(nombre_formulario).smkClear();
                    //var ruta_producto = '@Url.Action("PublicarOfertas", "Home")';
                    //alert(ruta_producto);
                    //window.location.href = ruta_producto;

                    location.reload();
                })
                    .catch(function (response) {
                        //SE ENVIA MENSAJE  DE GRABACION INCORRECTA

                        console.log(response);

                       // window.location.href = response.data;

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


