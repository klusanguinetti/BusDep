'use strict';
app.controller('eventoPublicidadListController', ['$scope', '$window', '$location', 'eventoPublicidadService', 'commonService', 'authService', '$rootScope', 'toastr', '$routeParams', 'Flash',
function ($scope, $window, $location, eventoPublicidadService, commonService, authService, $rootScope, toastr, $routeParams, Flash) {
    $scope.eventos = [];
    $scope.modulo = 'Abm Eventos Publicidad';

    var messageToDisplay = "";

    angular.element(function () {
        var action = $routeParams.action;

        var result = $routeParams.result;


        if (action == "add") {
            messageToDisplay = "<strong>¡Éxito!</strong> Has añadido el evento.";
        } else if (action == "edit") {
            messageToDisplay = "<strong>¡Éxito!</strong> Has editado el evento.";
        }


        if (result == "success") {
            message('success', messageToDisplay);
        }

        if (result == "notFound") {
            message('warning', '<strong>¡Hey!</strong> El evento que buscas no esta disponible.');
        }


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
        getEventoPublicidad();

    });

    $scope.DeletePublicidad = function (publicidad) {

        return eventoPublicidadService.deleteEventoPublicidad(publicidad).then(function (response) {

            messageToDisplay = "<strong>¡Éxito!</strong> Has eliminado el evento.";

            message('success', messageToDisplay);

            getEventoPublicidad();

        }).catch(function (err) {

            toastr.error('¡Error desconocido! ', 'Error');

        });

    };
    function message(type, message) {
        Flash.create(type, message, 5000);
    };
    function getEventoPublicidad() {

        eventoPublicidadService.getEventoPublicidadAll().then(function (response) {

            $scope.eventos = response.data;

        }).catch(function (err) {
            toastr.error('¡Ha ocurrido un error!', 'Error');
        });

    };
    $scope.abrirlink = (function (item) {
        $window.open(item.Link, '_blank');
    });
}]);