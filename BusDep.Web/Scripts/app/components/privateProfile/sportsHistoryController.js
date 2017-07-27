app.controller('sportsHistoryController', ['$scope', 'sportsHistoryService', '$http', '$rootScope', 'toastr',
function ($scope, sportsHistoryService, $http, $rootScope, toastr) {


    $scope.Mail = $rootScope.user.UserName;

    $scope.paises = {};

    $scope.datosPersonales = {};

    $scope.jugador = {};

    $scope.fichajes = {};
    $scope.perfiles = {};
    $scope.puestos = {};

    $scope.loginData = {
        Id: "",
        Mail: "",
        OldPassword: "",
        NewPassword: ""
    };

    angular.element(function () {

        sportsHistoryService.getUserDetails().then(function (response) {

            $http.get('json/paises.json').then(function (data) {
                $scope.paises = data.data;
            });

            $scope.datosPersonales = response.data;

            if (response.data.FechaNacimiento != null) {

                var date = moment(response.data.FechaNacimiento).format("YYYY/MM/DD");

                $scope.datosPersonales.FechaNacimiento = date;

            }

        }).catch(function (err) {

            toastr.error('¡Ha ocurrido un error cargando el perfil!', 'Error');

        });

        sportsHistoryService.getJugador().then(function (response) {
            $scope.jugador = response.data;
         }).catch(function (err) {
            toastr.error('¡Ha ocurrido un error!', 'Error');
         });
        sportsHistoryService.getFichajes().then(function (response) {
            $scope.fichajes = response.data;
        }).catch(function (err) {
            toastr.error('¡Ha ocurrido un error!', 'Error');
        });
        sportsHistoryService.getPerfiles().then(function (response) {
            $scope.perfiles = response.data;
            }).catch(function (err) {
            toastr.error('¡Ha ocurrido un error!', 'Error');
            });
        sportsHistoryService.getPuestos().then(function(response) {
            $scope.puestos = response.data;
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

            return sportsHistoryService.passwordUpdate(loginDataPost).then(function (response) {

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

    $scope.jugadorUpdate = function() {


        return sportsHistoryService.jugadorUpdate($scope.jugador).then(function(response) {

            toastr.success('¡Informacion guardada con éxito!', '¡Perfecto!');

            clearErrors();

        }).catch(function(err) {

                toastr.error('¡Error desconocido!', 'Error');
        });


    };
    $scope.UpdateProfile = function () {
        if ($scope.datosPersonales.PaisIso != '') {

            angular.forEach($scope.paises, function (value, key) {
                if (value.CodigoIso == $scope.datosPersonales.PaisIso) {
                    $scope.datosPersonales.Pais = value.Nombre;
                }
            });

            
        }
        if ($scope.datosPersonales.NacionalidadIso != '') {

            angular.forEach($scope.paises, function (value, key) {
                if (value.CodigoIso == $scope.datosPersonales.NacionalidadIso) {
                    $scope.datosPersonales.Nacionalidad = value.Nombre;
                }
            });

            
        }
        return sportsHistoryService.saveUserDetails($scope.datosPersonales).then(function (response) {

            toastr.success('¡Perfil actualizado con éxito!', '¡Perfecto!');

        }).catch(function (err) {

            toastr.error('¡Error desconocido!', 'Error');

        });

    };

    function clearErrors() {
        $scope.passwordForm.$setPristine();
        $scope.passwordForm.$setValidity();
        $scope.passwordForm.$setUntouched();
    }

}]);