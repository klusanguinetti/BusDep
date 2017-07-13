app.controller('privateProfileController', ['$scope', 'privateProfileService', 'authService', '$http', function ($scope, privateProfileService, authService, $http) {

    $scope.savedSuccessfully = false;
    $scope.message = "";

    $scope.Mail = authService.authentication.userName;

    $scope.paises = {};

    $scope.datosPersonales = {};

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