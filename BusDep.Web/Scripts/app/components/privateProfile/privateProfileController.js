app.controller('privateProfileController', ['$scope', 'privateProfileService', 'authService', '$http', function ($scope, privateProfileService, authService, $http) {

    $scope.savedSuccessfully = false;
    $scope.message = "";

    $scope.Mail = authService.authentication.userName;

    $scope.paises = {};

    $scope.datosPersonales = {};

    $scope.loginData = {
        Id: authService.authentication.datosPersonaId,
        Mail: $scope.Mail,
        OldPassword: "",
        Password: ""
    };

    angular.element(function () {
    
        privateProfileService.getUserDetails(authService.authentication.datosPersonaId).then(function (response) {

            $http.get('json/paises.json').then(function (data) {
                $scope.paises = data.data;
            });

            $scope.datosPersonales = response.data;

        },
        function (err) {

        });

    
    });


    $scope.passwordUpdate = function () {

        $scope.loginData.Password = window.btoa($scope.loginData.Password);

        $scope.loginData.OldPassword = window.btoa($scope.loginData.OldPassword);

        if ($scope.passwordForm.$valid) {

            privateProfileService.passwordUpdate($scope.loginData).then(function (response) {

                $scope.passwordChangeSuccess = true;
                $scope.messageType = "success";
                $scope.message = "¡Has actualizado tu contraseña con éxito!";
                $scope.messageIcon = "fa-check";

                $scope.loginData.Password = "";
                $scope.loginData.OldPassword = "";

            }).catch(function(err) {
                
                $scope.passwordChangeSuccess = true;
                $scope.messageType = "danger";
                $scope.message = "¡Contraseña actual inválida!";
                $scope.messageIcon = "fa-exclamation-triangle";

            });

        }

    };

    $scope.UpdateProfile = function () {

        privateProfileService.saveUserDetails($scope.datosPersonales).then(function (response) {

            alert('Datos salvados con exito');

        },
         function (err) {

         });

    };

}]);