'use strict';
app.controller('loginController', ['$scope', '$location', 'authService', '$timeout', 'authInterceptorService','toastr',
    function ($scope, $location, authService, $timeout, authInterceptorService,toastr) {

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
                        toastr.error('¡Usuario/Contraseña invalidos!', 'Error');
                    } else {
                        toastr.error('¡Error desconocido!', 'Error');
                    }

                });

            }

        };

    }]);