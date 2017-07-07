'use strict';
app.controller('loginController', ['$scope', '$location', 'authService', '$timeout', function ($scope, $location, authService, $timeout) {

    $scope.savedSuccessfully = false;
    $scope.message = "";

    $scope.loginData = {
        mail: "",
        password: ""
    };

    $scope.message = "";

    $scope.login = function () {

        authService.login($scope.loginData).then(function (response) {


            $location.path('/Home/Index');

        },
         function (err) {
             $scope.savedSuccessfully = true;
             $scope.message = "Usuario/Contraseña no encontrados";
         });
    };

}]);