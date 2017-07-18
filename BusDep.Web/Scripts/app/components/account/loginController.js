'use strict';
app.controller('loginController', ['$scope', '$location', 'authService', '$timeout', 'authInterceptorService',
    function ($scope, $location, authService, $timeout, authInterceptorService) {

        /*Declaración de variables*/

        $scope.savedSuccessfully = false;
        $scope.errorLogin = false;
        $scope.buttonDisabled = false;

        $scope.loginData = {
            mail: "",
            password: ""
        };

        $scope.message = "";

        /*Declaración de funciones*/

        $scope.login = function () {

            if ($scope.loginForm.$valid) {

                $scope.buttonDisabled = true;

                authService.login($scope.loginData).then(function (response) {

                    $location.path('/Home/Index');

                }).catch(function (err) {

                    if (err.status == "404") {
                        $scope.errorLogin = true;
                    }

                    $scope.buttonDisabled = false;

                });

            }

        };

    }]);