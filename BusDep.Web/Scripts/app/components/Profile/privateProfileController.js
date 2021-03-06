﻿app.controller('privateProfileController', ['$scope', 'privateProfileService', 'commonService', '$http', '$rootScope', 'toastr', '$filter',
function ($scope, privateProfileService, commonService, $http, $rootScope, toastr, $filter) {


    $scope.Mail = $rootScope.user.UserName;
    $scope.autoEvaluacion = {};
    $scope.paises = {};

    $scope.datosPersonales = {};

    $scope.jugador = {};

   
    $scope.sosVisible = true;
    $scope.fechaNacimiento = null;

    $scope.tipoDocumento = [
        {
            "Nombre": "Documento Nacional de Identidad"
        },
        {
            "Nombre": "Pasaporte"
        },
        {
            "Nombre": "Cédula"
        }
    ];


    $scope.loginData = {
        Id: "",
        Mail: "",
        OldPassword: "",
        NewPassword: ""
    };

    $scope.modulo = 'Mis Datos';

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

        privateProfileService.getUserDetails().then(function (response) {
            $http.get('json/paises.json').then(function (data) {
                $scope.paises = $filter('orderBy')(data.data, 'Nombre');
            });
            $scope.datosPersonales = response.data;
            if (response.data.FechaNacimiento != null) {
                $scope.fechaNacimiento = response.data.FechaNacimientoTexto;
            }
        }).catch(function (err) {
            toastr.error('¡Ha ocurrido un error cargando el perfil!', 'Error');
        });

        privateProfileService.getJugador().then(function (response) {
            $scope.jugador = response.data;
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

    $scope.jugadorUpdate = function () {
        return privateProfileService.jugadorUpdate($scope.jugador).then(function (response) {
            toastr.success('¡Informacion guardada con éxito!', '¡Perfecto!');
            clearErrors();
        }).catch(function (err) {

            toastr.error('¡Error desconocido!', 'Error');
        });
    };

    $scope.UpdateProfile = function () {
        if ($scope.datosPersonales.PaisIso != '' && $scope.datosPersonales.PaisIso!=null) {
            angular.forEach($scope.paises, function(value, key) {
                if (value.CodigoIso == $scope.datosPersonales.PaisIso) {
                    $scope.datosPersonales.Pais = value.Nombre;
                }
            });
        } else {
            $scope.datosPersonales.Pais = null;
        }
        if ($scope.datosPersonales.NacionalidadIso != '' && $scope.datosPersonales.NacionalidadIso != null) {
            angular.forEach($scope.paises, function (value, key) {
                if (value.CodigoIso == $scope.datosPersonales.NacionalidadIso) {
                    $scope.datosPersonales.Nacionalidad = value.Nombre;
                }
            });
        }
        else {
            $scope.datosPersonales.Nacionalidad = null;
        }
        if ($scope.datosPersonales.NacionalidadIso1 != '' && $scope.datosPersonales.NacionalidadIso1 != null) {
            angular.forEach($scope.paises, function (value, key) {
                if (value.CodigoIso == $scope.datosPersonales.NacionalidadIso1) {
                    $scope.datosPersonales.Nacionalidad1 = value.Nombre;
                }
            });
        }
        else {
            $scope.datosPersonales.Nacionalidad1 = null;
        }
        $scope.datosPersonales.FechaNacimientoTexto = $scope.fechaNacimiento;
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