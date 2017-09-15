'use strict';
app.controller('registerController', ['$scope', '$location', '$timeout', 'authService', 'toastr',
    function ($scope, $location, $timeout, authService, toastr) {

    $scope.savedSuccessfully = false;

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

           return authService.saveRegistration($scope.registration).then(function (response) {

                $scope.savedSuccessfully = true;
                startTimer();

           }).catch(function (err) {

               if (err.status == "422") {
                   toastr.error('¡El email ya se encuentra registrado!', 'Error');
               } else {
                   toastr.error('¡Error desconocido!', 'Error');
               }

           });

        }

    };

    var startTimer = function () {

        var loginData = {
            mail: $scope.registration.Mail,
            password: window.btoa($scope.registration.Password)
        };

        var timer = $timeout(function () {

            $location.path('/Account/Login');

        }, 3000);
    }

}]);