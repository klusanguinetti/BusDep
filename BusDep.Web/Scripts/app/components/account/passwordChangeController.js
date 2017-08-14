app.controller('passwordChangeController', ['$scope', 'passwordChangeService', '$http', '$rootScope', 'toastr',
function ($scope, passwordChangeService, $http, $rootScope, toastr) {


    $scope.Mail = $rootScope.user.UserName;

    $scope.datosPersonales = {};

    
    $scope.loginData = {
        Id: "",
        Mail: "",
        OldPassword: "",
        NewPassword: ""
    };

    angular.element(function () {

        passwordChangeService.getUserDetails().then(function (response) {
            $scope.datosPersonales = response.data;
        }).catch(function (err) {

            toastr.error('¡Ha ocurrido un error cargando de la información!', 'Error');

        });
    });


    $scope.passwordUpdate = function () {

        var loginDataPost = {
            Id: $scope.loginData.Id,
            Mail: $scope.loginData.Mail,
            OldPassword: window.btoa($scope.loginData.OldPassword),
            NewPassword: window.btoa($scope.loginData.NewPassword)
        };

        if ($scope.passwordForm.$valid) {

            return passwordChangeService.passwordUpdate(loginDataPost).then(function (response) {

                toastr.success('¡Contraseña actualizada con éxito!', '¡Perfecto!');

                $scope.loginData.NewPassword = "";
                $scope.loginData.OldPassword = "";

                clearErrors();

            }).catch(function (err) {

                if (err.status == "404") {
                    toastr.error('¡La contraseña actual es incorrecta!', 'Error');
                } else {
                    toastr.error('¡Error desconocido!', 'Error');
                }

            });

        }

    };

    function clearErrors() {
        $scope.passwordForm.$setPristine();
        $scope.passwordForm.$setValidity();
        $scope.passwordForm.$setUntouched();
    }

}]);