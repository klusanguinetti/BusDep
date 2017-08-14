'use strict';
app.controller('passwordRecoveryController', ['$scope', '$location', 'authService', '$timeout', 'authInterceptorService','Flash','$routeParams',
function ($scope, $location, authService, $timeout, authInterceptorService, Flash, $routeParams) {

        /*Declaración de variables*/

        $scope.recoveryData = {
            Mail: "",
            Codigo: "",
            Password: "",
            VerificacionPassword: ""
        };

        $scope.message = "";

        /*Declaración de funciones*/

        $scope.passwordRecovery = function () {

            if ($scope.passwordRecoveryForm.$valid) {

                return authService.passwordRecovery($scope.recoveryData).then(function (response) {

                    message('success', 'Verifica tu correo, enviamos un enlace para recuperar tu contraseña.');

                    $scope.recoveryData.Mail = "";

                    clearErrors();

                }).catch(function (err) {

                    if (err.status == "422" ) {
                        message('success', 'Verifica tu correo, enviamos un enlace para recuperar tu contraseña.');
                    } else {
                        message('danger', 'Ha ocurrido un error procesando tu petición.');
                    }

                });

            }

        };

        function clearErrors() {

            $scope.passwordRecoveryForm.$setPristine();
            $scope.passwordRecoveryForm.$setValidity();
            $scope.passwordRecoveryForm.$setUntouched();

        }

        function message(type, message) {
            Flash.create(type, message, 5000, { container: 'passwordRecovery' });
        };

    }]);