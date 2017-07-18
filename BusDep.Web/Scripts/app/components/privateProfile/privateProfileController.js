app.controller('privateProfileController', ['$scope', 'privateProfileService', 'authService', '$http','$rootScope',
    function ($scope, privateProfileService, authService, $http, $rootScope) {

    $scope.savedSuccessfully = false;
    $scope.message = "";

    $scope.Mail = $rootScope.user.UserName;

    $scope.paises = {};

    $scope.datosPersonales = {};

    $scope.loginData = {
        Id: "",
        Mail: "",
        OldPassword: "",
        NewPassword: ""
    };

    angular.element(function () {
    
        privateProfileService.getUserDetails().then(function (response) {

            $http.get('json/paises.json').then(function (data) {
                $scope.paises = data.data;
            });

            $scope.datosPersonales = response.data;

        },
        function (err) {

        });

    
    });


    $scope.passwordUpdate = function () {

        $scope.loginData.NewPassword = window.btoa($scope.loginData.NewPassword);

        $scope.loginData.OldPassword = window.btoa($scope.loginData.OldPassword);

        if ($scope.passwordForm.$valid) {

            privateProfileService.passwordUpdate($scope.loginData).then(function (response) {

                $scope.passwordChangeSuccess = true;
                $scope.messageType = "success";
                $scope.message = "¡Has actualizado tu contraseña con éxito!";
                $scope.messageIcon = "fa-check";

                $scope.loginData.NewPassword = "";
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