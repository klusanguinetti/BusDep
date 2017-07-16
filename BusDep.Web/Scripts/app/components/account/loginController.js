'use strict';
app.controller('loginController', ['$scope', '$location', 'authService', '$timeout', function ($scope, $location, authService, $timeout) {

    $scope.savedSuccessfully = false;
    $scope.errorLogin = false;
    $scope.buttonDisabled = false;

    $scope.loginData = {
        mail: "",
        password: ""
    };

    $scope.message = "";

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