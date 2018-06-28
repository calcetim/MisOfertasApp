app.controller('registroController', function ($http, $scope, URL_SERVICIOS) {


    //BUSCA AREAS DE INTERES   
    $http.get(URL_SERVICIOS.BASE_URL + 'Listas/getAreasInteres').then(function (response) {
        $scope.areas = response.data;
    })

    //BUSCA TIENDAS DE INTERES
    $http.get(URL_SERVICIOS.BASE_URL + 'Listas/getTiendas').then(function (response) {
        $scope.tiendas =  response.data ;
    })


    //BUSCA COMUNAS POR REGION
    $scope.getValueRegion = function () {
        $scope.regionId = $scope.model_regiones;
        $http.get(URL_SERVICIOS.BASE_URL + 'Listas/getComunasPorRegion?regionId=' + $scope.regionId).then(function (response) {
            $scope.comunas = response.data;
        })
    }

    //BUSCA REGIONES
    $http.get(URL_SERVICIOS.BASE_URL + 'Listas/getRegiones').then(function (response) {
        $scope.regiones = response.data;
    })


    $scope.isChecked = function (id, matches) {
        var isChecked = false;
        angular.forEach(matches, function (match) {
            if (match === id) {
                isChecked = true;
            }
        });
        return isChecked;
    }


    //BUSCA SI EXISTE LA PERSONA INGRESADA


    $scope.buscarUsuarioPorRut = function () {

        var nombre_formulario = '#rut';

        if ($(nombre_formulario).smkValidate()) {


            var rut_verificador = $("#rut").val().split('-');

            var listaDatos = {
                "RUT": rut_verificador[0]
            };

            $http({
                method: 'POST',
                url: URL_SERVICIOS.BASE_URL + 'Home/buscarUsuarioPorRut',
                data: angular.toJson(listaDatos)
            }).then(function (response) {

                
                if (response.data.existeUsuario == true) {
                    //SE ENVIA MENSAJE USUARIO EXISTE
                    $.smkAlert({
                        text: 'El usuario ya se encuentra registrado',
                        type: 'danger',
                        position: 'bottom-center',
                        time: 5
                    });

                    $(nombre_formulario).smkClear();
                }


            }).catch(function (response) {
                //SE ENVIA MENSAJE  DE GRABACION INCORRECTA
                $.smkAlert({
                    text: 'Error al validar usuario',
                    type: 'danger',
                    position: 'bottom-center',
                    time: 10
                });

            })

        }
    }


 

    // SE ENVIA INFORMACION DEL REGISTRO
    $scope.validate = function () {

        var nombre_formulario = '#register-form';


        console.log($scope.enviarFormularioIngresoOferta);

        if ($(nombre_formulario).smkValidate()) {
            $scope.enviarFormularioRegistro = function () {
                valor = $scope.form;

              
                console.log(valor.tiendas_interes);

               

                var misPreferencias =
                    [{
                        "ID": 1,
                        "Tienda": { "ID_TIENDA": '1', 'NOMBRE': 'dakaassd' }
                    },
                        {
                            "ID": 2,
                            "Tienda": { "ID_TIENDA": '2', 'NOMBRE': 'sssssss' }
                        }
                    ];

                var preferencias_tiendas = Object.keys(valor.tiendas_interes).map(e => valor.tiendas_interes[e]);


                var preferencias_areas  = Object.keys(valor.areas_interes).map(e => valor.areas_interes[e]);


                // //plan B
                // var preferencias = [];
                //angular.forEach(valor.tiendas_interes, function (value, key) {                  
                //    this.push(value);
                //}, preferencias);               
                //console.log(preferencias);


             
              
         

                var rut_verificador = $("#rut").val().split('-');
                var listaDatos = {
                    "usuario":
                        {
                            "USERNAME": valor.username,
                            "PASSW": valor.passwd,
                            "RECIBIR_INFORMACION": valor.recibir_email,
                            "TipoUsuario": {
                                "ID_TIPO_USUARIO": 4
                            },
                            "PreferenciaTiendaUsuario": preferencias_tiendas,
                            "PreferenciaRubroUsuario": preferencias_areas,
                        "Persona": {
                            "DV_RUT": rut_verificador[1],
                            "RUT": rut_verificador[0],
                            "PRIMER_NOMBRE": valor.nombres,
                            "APELLIDO_PATERNO": valor.apellido_pat,
                            "SEGUNDO_NOMBRE": valor.apellido_mat,
                            "EMAIL": valor.mail,
                            "Comuna": {
                                "ID_COMUNA": valor.comuna
                            }
                        }
                    }
                };


                console.log(listaDatos);

                $http({

                    method: 'POST',
                    url: URL_SERVICIOS.BASE_URL + 'Home/GuardarUsuario',
                    data: angular.toJson(listaDatos)

                }).then(function (response) {

                    //SE ENVIA MENSAJE  DE GRABACION CORRECTA
                    
                    $.smkAlert({
                        text: 'El ingreso de su consulta a sido exitoso',
                        type: 'success',
                        position: 'bottom-center',
                        time: 10
                    });

                    // SE LIMPIA FORMULARIO UNA VEZ GRADO CORRECTAMENTE
                    $(nombre_formulario).smkClear();


                })
                    .catch(function (response) {
                        //SE ENVIA MENSAJE  DE GRABACION INCORRECTA
                        $.smkAlert({
                            text: 'Error al ingresar consulta.',
                            type: 'danger',
                            position: 'bottom-center',
                            time: 10
                        });

                    })

            }

        }
    };
});


// DatePicker -> NgModel
app.directive('datePicker', function () {
    return {
        require: 'ngModel',
        link: function (scope, element, attr, ngModel) {
            $(element).datetimepicker({
                locale: 'ES',
                format: 'DD-MM-YYYY',
                parseInputDate: function (data) {
                    if (data instanceof Date) {
                        return moment(data);
                    } else {
                        return moment(new Date(data));
                    }
                },
                maxDate: new Date()
            });

            $(element).on("dp.change", function (e) {
                ngModel.$viewValue = e.date;
                ngModel.$commitViewValue();
            });
        }
    };
});

// DatePicker Input NgModel->DatePicker
app.directive('datePickerInput', function () {
    return {
        require: 'ngModel',
        link: function (scope, element, attr, ngModel) {
            // Trigger the Input Change Event, so the Datepicker gets refreshed
            scope.$watch(attr.ngModel, function (value) {
                if (value) {
                    element.trigger("change");
                }
            });
        }
    };
});
