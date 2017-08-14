'use strict';
app.controller('passwordRecoveryUpdateController', ['$scope', '$location', 'authService', '$timeout', 'authInterceptorService', 'Flash', '$routeParams',
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

        angular.element(function () {

            var validationToken = $routeParams.token;

            if (validationToken == "" || validationToken == null) {
                $location.path('/Home/Index');
            }

            //validar q sea un numero TODO

            $scope.recoveryData.Codigo = validationToken;

        });

        $scope.passwordRecoveryUpdate = function () {

            if ($scope.passwordRecoveryForm.$valid) {

                var recoveryDataPost = {
                    Mail: $scope.recoveryData.Mail,
                    Codigo: $scope.recoveryData.Codigo,
                    Password: window.btoa($scope.recoveryData.Password),
                    VerificacionPassword: window.btoa($scope.recoveryData.VerificacionPassword)
                };

                return authService.passwordRecoveryUpdate(recoveryDataPost).then(function (response) {

                    $location.path("/Account/Login").search({ lastAction: "passwordChanged" });

                }).catch(function (err) {

                    message('danger', err.data);

                });

            }

        };

        function clearErrors() {
            $scope.passwordRecoveryForm.$setPristine();
            $scope.passwordRecoveryForm.$setValidity();
            $scope.passwordRecoveryForm.$setUntouched();
        }

        function message(type, message) {
            Flash.create(type, message, 10000);
        };

    }]);