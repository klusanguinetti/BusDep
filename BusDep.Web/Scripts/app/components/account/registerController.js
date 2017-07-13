'use strict';
app.controller('registerController', ['$scope', '$location', '$timeout', 'authService', function ($scope, $location, $timeout, authService) {

    $scope.savedSuccessfully = false;
    $scope.buttonDisabled = false;

    $scope.fixedWidth = window.innerHeight - 220;

    $scope.registration = {
        Nombre: "",
        Apellido: "",
        TipoUsuario: "Jugador",
        Mail: "",
        Password: ""
    };

    $scope.signUp = function () {

        if ($scope.userForm.$valid) {

            $scope.buttonDisabled = true;

            authService.saveRegistration($scope.registration).then(function (response) {

                $scope.savedSuccessfully = true;
                startTimer();

            },
             function (response) {
                 var errors = [];
                 for (var key in response.data.modelState) {
                     for (var i = 0; i < response.data.modelState[key].length; i++) {
                         errors.push(response.data.modelState[key][i]);
                     }
                 }
                 $scope.buttonDisabled = false;
                 $scope.message = "Failed to register user due to:" + errors.join(' ');
             });

        }

    };

    var startTimer = function () {

        $scope.loginData = {
            mail: $scope.registration.Mail,
            password: $scope.registration.Password
        };

        var timer = $timeout(function () {

            $timeout.cancel(timer);

            authService.login($scope.loginData).then(function (response) {

                $location.path('/Profile/PrivateProfile');

            },
            function (err) {

            });

 
        }, 3000);
    }

}]);