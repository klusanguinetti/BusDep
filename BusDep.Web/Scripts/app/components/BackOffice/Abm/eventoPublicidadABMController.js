'use strict';
app.controller('eventoPublicidadABMController', ['$scope', 'eventoPublicidadService', 'Upload', '$location', 'commonService', 'authService', '$rootScope', 'toastr', '$routeParams', '$timeout',
function ($scope, eventoPublicidadService, Upload, $location, commonService, authService, $rootScope, toastr, $routeParams, $timeout) {
    $scope.eventoPublicidad = {};
    $scope.modulo = 'Abm Eventos Publicidad';
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
        var eventoPublicidadId = $routeParams.id;
        $scope.titulo = "Agregar nueva Evento";

        if (eventoPublicidadId != null) {
            eventoPublicidadId = parseInt(eventoPublicidadId, 10);
            $scope.titulo = "Editar Evento";

            action = "edit";

            return eventoPublicidadService.getEventoPublicidadById(eventoPublicidadId).then(function (response) {

                if (response.data == "") {
                    $location.path('/EventoPublicidadList/').search({ action: action, result: 'notFound' });
                }

                $scope.eventoPublicidad = response.data;
                if ($scope.eventoPublicidad.ImageUrl != null)
                    $scope.picFile = $scope.eventoPublicidad.ImageUrl;

            }).catch(function (err) {

                if (Error.Code == 123)
                    toastr.error(Error.Message, 'Error');
                else
                    toastr.error('¡Error desconocido! ', 'Error');

            });

        }
    });

    $scope.saveEventoPublicidad = function () {
        return eventoPublicidadService.saveEventoPublicidad($scope.eventoPublicidad).then(function (response) {
            $location.path('/EventoPublicidadList/').search({
                action: action,
                result: 'success'
            });
        }).catch(function (err) {

            toastr.error('¡Error desconocido! ', 'Error');

        });



    };

    $scope.uploadFiles = function (file, errFiles) {

        $scope.f = file;

        $scope.errFile = errFiles && errFiles[0];

        if (file) {

            file.upload = Upload.upload({
                url: '/api/EventoPublicidad/SaveImageEventoPublicidad',
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