'use strict';
app.controller('publicidadABMController', ['$scope', '$window', '$location', 'publicidadService', 'Upload', 'commonService', 'authService', '$rootScope', 'toastr','$routeParams','$timeout',
function ($scope, $window, $location, publicidadService, Upload, commonService, authService, $rootScope, toastr, $routeParams, $timeout) {
    $scope.publicidad = {};
    $scope.modulo = 'Abm Publicidad';
    $scope.titulo = '';
    $scope.picFile = "https://allwiners.blob.core.windows.net/photos/default_avatar-thumb.jpg";

    $scope.f = null;
    $scope.errFile = null;
    var action = "add";
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
        var publicidadId = $routeParams.id;
        $scope.titulo = "Agregar nueva publicidad";

        if (publicidadId != null) {
            publicidadId = parseInt(publicidadId, 10);
            $scope.titulo = "Editar publicidad";

            action = "edit";

            return publicidadService.getPublicidadById(publicidadId).then(function (response) {

                if (response.data == "") {
                    $location.path('/Publicidad/List/').search({ action: action, result: 'notFound' });
                }

                $scope.publicidad = response.data;
                $scope.picFile = $scope.publicidad.ImageUrl;

            }).catch(function (err) {

                toastr.error('¡Error desconocido! ', 'Error');

            });

        }
    });

    $scope.savePublicidad = function () {
        return publicidadService.savePublicidad($scope.publicidad, $scope.f).then(function (response) {
            if (response.data == "Ok") {
                $location.path('/PublicidadList').search({
                    action: action,
                    result: 'success'
                });
            }
        }).catch(function (err) {

            toastr.error('¡Error desconocido! ', 'Error');

        });



    };

     $scope.uploadFiles = function (file, errFiles) {

        $scope.f = file;

        $scope.errFile = errFiles && errFiles[0];
         
        if (file) {

            file.upload = Upload.upload({
                url: '/api/ABM/SaveImagePublicidad',
                data: { file: file }
            });

            file.upload.then(function (response) {
                $timeout(function () {
                    $scope.headerResult = response.data;
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
}]);