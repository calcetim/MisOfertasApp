app.controller('registroController', function ($http, $scope, URL_SERVICIOS) {


    console.log(URL_SERVICIOS);



    $http.get(URL_SERVICIOS.BASE_URL + 'Listas/getAreasInteres').then(function (response) {
        $scope.areas = response.data;
        console.log($scope.roles);
    })

    $http.get(URL_SERVICIOS.BASE_URL + 'Listas/getTiendas').then(function (response) {
        $scope.roles = response.data;
        console.log($scope.roles);
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



    $('#txtUploadFile').on('change', function (e) {

        $scope.archivos = e.target.files;

        console.log($scope.archivos);
    });



    $scope.getValueRegion = function () {
        $scope.regionId = $scope.model_regiones;
        $http.get(URL_SERVICIOS.BASE_URL + 'Listas/getComunasPorRegion?regionId=' + $scope.regionId).then(function (response) {
            $scope.comunas = response.data;
            //console.log(response.data);

        })
    }

    $http.get(URL_SERVICIOS.BASE_URL + 'Listas/getRegiones').then(function (response) {
        $scope.regiones = response.data;
        console.log($scope.regiones);
    })



    $scope.validate = function () {

        var nombre_formulario = '#register-form';

        if ($(nombre_formulario).smkValidate()) {
            $scope.enviarFormularioRegistro = function () {


                valor = $scope.form;
                console.log(valor);

                var rut_verificador = $("#rut").val().split('-');

                var listaDatos = {
                    "detalle_consulta": valor.detalle_consulta,
                    "Usuario": {
                        "dv": rut_verificador[1],
                        "rut": rut_verificador[0],
                        "nombres": valor.nombres,
                        "apellido_paterno": valor.apellido_paterno,
                        "apellido_materno": valor.apellido_materno,
                        "correo": valor.correo,
                        "telefono": valor.telefono,
                        "ciudad": valor.ciudad,
                        "fecha_nacimiento": valor.fecha_nacimiento,
                        "Nacionalidad": {
                            "id": valor.Nacionalidad
                        },
                        "Pais_residencia": {
                            "id": valor.Pais_residencia
                        },
                        "Genero": {
                            "id": valor.Genero
                        },
                        "Comuna": {
                            "id": valor.Comuna
                        }

                    }
                };

                console.log(listaDatos);

                $http({
                    method: 'POST',
                    url: URL_SERVICIOS.BASE_URL + 'Consulta/ingresarConsulta',
                    headers: { 'Content-Type': undefined },

                    transformRequest: function (data) {
                        var formData = new FormData();
                        formData.append("jsonData", angular.toJson(listaDatos));

                        //alert(data.files.length);

                        for (var i = 0; i < $scope.archivos.length; i++) {
                            formData.append("archivo_consulta_" + i, $scope.archivos[i]);
                        }

                        return formData;
                    },
                    data: { jsonData: $scope.jsonData, files: $scope.archivos }
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
