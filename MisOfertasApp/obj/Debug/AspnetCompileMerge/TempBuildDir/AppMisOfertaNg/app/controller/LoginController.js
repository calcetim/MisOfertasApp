app.controller('loginController', function ($http, $scope, URL_SERVICIOS) {

    $scope.validateLogin = function () {

        var nombre_formulario = '#login-form';

        if ($(nombre_formulario).smkValidate()) {
            $scope.enviarFormularioLogin = function () {


                valor = $scope.form;
                console.log(valor);


                var listaDatos = {
                    "usuario": valor.usuario,
                    "clave": valor.clave
                };

                console.log(listaDatos);

                $http({
                    method: 'POST',
                    url: URL_SERVICIOS.BASE_URL + 'Home/Login',
                    data: angular.toJson(listaDatos)
                }).then(function (response) {




                    window.location.href = response.data;

                    //SE ENVIA MENSAJE  DE GRABACION CORRECTA
                    $.smkAlert({
                        text: 'El ingreso de su consulta a sido exitoso',
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
                            text: 'Usuario o contraseña invalidos',
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


