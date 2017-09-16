'use strict';
app.controller('loginController', ['$scope', '$location', 'authService', '$timeout', 'authInterceptorService', 'Flash', '$routeParams',
function ($scope, $location, authService, $timeout, authInterceptorService, Flash, $routeParams) {

    /*Carga de interfaz*/

    var lastAction = $routeParams.lastAction;

    console.log(lastAction);

    if (lastAction == "passwordChanged") {
        message('success', 'Tu contraseña fue actualizada con éxito, prueba iniciando sesión de nuevo.');
    }

    /*Declaración de variables*/

    $scope.loginData = {
        mail: "",
        password: ""
    };

    $scope.message = "";

    /*Declaración de funciones*/

    $scope.login = function () {

        if ($scope.loginForm.$valid) {

            return authService.login($scope.loginData).then(function (response) {

                $location.path('/Home/Index');

            }).catch(function (err) {

                if (err.status == "404") {
                    message('danger', '¡Usuario/Contraseña invalidos!');
                } else {
                    message('danger', '¡Error desconocido!');
                }

            });

        }

    };

    function message(type, message) {
        Flash.create(type, message, 5000, { container: 'login' });
    };

}]);