﻿app.controller('sportDataController', ['$scope', 'privateProfileService', 'commonService', '$http', '$rootScope', 'toastr', '$filter', 'Upload', '$timeout', 'headerProfileService',
function ($scope, privateProfileService, commonService, $http, $rootScope, toastr, $filter, Upload, $timeout, headerProfileService) {


    $scope.Mail = $rootScope.user.UserName;

    $scope.datosPersonales = {};

    $scope.jugador = {};

    $scope.fichajes = {};
    $scope.perfiles = {};
    $scope.puestos = {};
    $scope.pies = {};
    $scope.sosVisible = true;

    $scope.myImage = "https://allwiners.blob.core.windows.net/photos/default-banner.jpg";

    $scope.modulo = 'Datos Deportivos';

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


        privateProfileService.getJugador().then(function (response) {

            $scope.jugador = response.data;

            if (response.data.FotoCuertoEntero != null) {
                $scope.myImage = response.data.FotoCuertoEntero;
            }

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

        privateProfileService.getPuestos().then(function (response) {
            $scope.puestos = response.data;
        }).catch(function (err) {
            toastr.error('¡Ha ocurrido un error!', 'Error');
        });

        privateProfileService.getPies().then(function (response) {
            $scope.pies = response.data;
        }).catch(function (err) {
            toastr.error('¡Ha ocurrido un error!', 'Error');
        });


    });


    $scope.jugadorUpdate = function () {


        return privateProfileService.jugadorUpdate($scope.jugador).then(function (response) {

            toastr.success('¡Informacion guardada con éxito!', '¡Perfecto!');

            clearErrors();

        }).catch(function (err) {

            toastr.error('¡Error desconocido!', 'Error');
        });


    };

    $scope.upload = function (file, errFiles) {

        $scope.f = file;

        $scope.errFile = errFiles && errFiles[0];

        if (file) {

            file.upload = Upload.upload({
                url: 'api/Files/AddFotoCuertoEntero/',
                data: { file: file }
            });

            file.upload.then(function (response) {
                $timeout(function () {
                    $scope.result = response.data;
                });
            }, function (response) {
                if (response.status > 0)
                    $scope.errorMsg = response.status + ': ' + response.data;
            }, function (evt) {
                file.progress = Math.min(100, parseInt(100.0 *
                                         evt.loaded / evt.total));
            });

        }

    }

    $scope.removePhotoCuerpoCompleto = function () {

        return headerProfileService.removePhotoCuerpoCompleto().then(function (response) {

            $scope.myImage = "https://allwiners.blob.core.windows.net/photos/default-banner.jpg";

        }).catch(function (err) {

            console.log("Error: " + err);

        });

    };

    function clearErrors() {
        $scope.passwordForm.$setPristine();
        $scope.passwordForm.$setValidity();
        $scope.passwordForm.$setUntouched();
    }

}]);