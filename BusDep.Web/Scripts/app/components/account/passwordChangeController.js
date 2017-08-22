app.controller('passwordChangeController', ['$scope', 'passwordChangeService', 'commonService', '$http', '$rootScope', 'toastr',
function ($scope, passwordChangeService, commonService, $http, $rootScope, toastr) {


    $scope.Mail = $rootScope.user.UserName;
    $scope.perfilShort = {};
    $scope.datosPersonales = {};

    
    $scope.loginData = {
        Id: "",
        Mail: "",
        OldPassword: "",
        NewPassword: ""
    };
    $scope.modulo = 'Cambio de Password';
    $scope.moduloicono = '';

    angular.element(function () {
        
        commonService.getMenu().then(function (response) {
            $rootScope.user.menu = response.data;
            angular.forEach($rootScope.user.menu, function (value, key) {
                if (value.Descripcion == $scope.modulo) {
                    $scope.moduloicono = value.Icono;
                }
            });

        }).catch(function (err) {
            toastr.error('¡Ha ocurrido un error!', 'Error');
        });


        passwordChangeService.getUserDetails().then(function (response) {
            $scope.datosPersonales = response.data;
        }).catch(function (err) {

            toastr.error('¡Ha ocurrido un error cargando de la información!', 'Error');

        });
        commonService.getPerfilJugadorShort().then(function (response) {

            $scope.perfilShort = response.data;

        }).catch(function (err) {
            toastr.error('¡Ha ocurrido un error!', 'Error');
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