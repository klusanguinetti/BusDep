app.controller('privateProfileController', ['$scope', 'privateProfileService', 'commonService', '$http', '$rootScope', 'toastr',
function ($scope, privateProfileService, commonService, $http, $rootScope, toastr) {


    $scope.Mail = $rootScope.user.UserName;
    $scope.autoEvaluacion = {};
    $scope.paises = {};

    $scope.datosPersonales = {};

    $scope.jugador = {};

    $scope.fichajes = {};
    $scope.perfiles = {};
    $scope.puestos = {};
    $scope.pies = { };

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

            if (response.data.FechaNacimiento != null) {

                var date = moment(response.data.FechaNacimiento).format("DD/MM/YYYY");

                $scope.datosPersonales.FechaNacimiento = date;

            }
            commonService.getPerfilJugadorShort().then(function (response) {

                $scope.perfilShort = response.data;

            }).catch(function (err) {
                toastr.error('¡Ha ocurrido un error!', 'Error');
            });

        }).catch(function (err) {

            toastr.error('¡Ha ocurrido un error cargando el perfil!', 'Error');

        });

        privateProfileService.getJugador().then(function (response) {
            $scope.jugador = response.data;
         }).catch(function (err) {
            toastr.error('¡Ha ocurrido un error!', 'Error');
         });
        privateProfileService.getFichajes().then(function (response) {
            $scope.fichajes = response.data;
        }).catch(function (err) {
            toastr.error('¡Ha ocurrido un error!', 'Error');
        });
        privateProfileService.getPerfiles().then(function (response) {
            $scope.perfiles = response.data;
            }).catch(function (err) {
            toastr.error('¡Ha ocurrido un error!', 'Error');
            });
        privateProfileService.getPuestos().then(function(response) {
            $scope.puestos = response.data;
            }).catch(function (err) {
            toastr.error('¡Ha ocurrido un error!', 'Error');
            });
        privateProfileService.getPies().then(function(response) {
            $scope.pies = response.data;
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

            return privateProfileService.passwordUpdate(loginDataPost).then(function (response) {

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


        return privateProfileService.jugadorUpdate($scope.jugador).then(function(response) {

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
        if ($scope.datosPersonales.NacionalidadIso1 != '') {

            angular.forEach($scope.paises, function (value, key) {
                if (value.CodigoIso == $scope.datosPersonales.NacionalidadIso1) {
                    $scope.datosPersonales.Nacionalidad1 = value.Nombre;
                }
            });
        }
        return privateProfileService.saveUserDetails($scope.datosPersonales).then(function (response) {

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