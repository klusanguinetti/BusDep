app.controller('privateProfileController', ['$scope', 'privateProfileService', 'authService', function ($scope, privateProfileService, authService) {

    $scope.savedSuccessfully = false;
    $scope.message = "";

    $scope.Mail = authService.authentication.userName;

    $scope.datosPersonales = {};

    angular.element(function () {

        privateProfileService.getUserDetails(authService.authentication.datosPersonaId).then(function (response) {

            $scope.datosPersonales = response.data;

        },
        function (err) {
            $scope.savedSuccessfully = true;
            $scope.message = "Usuario/Contraseña no encontrados";
        });

    
    });

    $scope.UpdateProfile = function () {

        privateProfileService.saveUserDetails($scope.datosPersonales).then(function (response) {

            alert('Datos salvados con exito');

        },
         function (err) {
             $scope.savedSuccessfully = true;
             $scope.message = "Usuario/Contraseña no encontrados";
         });

    };

}]);