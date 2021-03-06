﻿'use strict';
app.controller('eventoPublicidadListController', ['$scope', '$window', '$location', 'eventoPublicidadService', 'commonService', 'authService', '$rootScope', 'toastr', '$routeParams', 'Flash',
function ($scope, $window, $location, eventoPublicidadService, commonService, authService, $rootScope, toastr, $routeParams, Flash) {
    $scope.publicidades = [];
    $scope.modulo = 'Abm Publicidad';

    var messageToDisplay = "";

    angular.element(function () {
        var action = $routeParams.action;

        var result = $routeParams.result;


        if (action == "add") {
            messageToDisplay = "<strong>¡Éxito!</strong> Has añadido la publicidad.";
        } else if (action == "edit") {
            messageToDisplay = "<strong>¡Éxito!</strong> Has editado la publicidad.";
        }


        if (result == "success") {
            message('success', messageToDisplay);
        }

        if (result == "notFound") {
            message('warning', '<strong>¡Hey!</strong> La publicidad que buscas no esta disponible.');
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
        getPublicidad();

    });

    $scope.DeletePublicidad = function (publicidad) {

        return eventoPublicidadService.deletePublicidad(publicidad).then(function (response) {

            messageToDisplay = "<strong>¡Éxito!</strong> Has eliminado la publicidad.";

            message('success', messageToDisplay);

            getPublicidad();

        }).catch(function (err) {

            toastr.error('¡Error desconocido! ', 'Error');

        });

    };
    function message(type, message) {
        Flash.create(type, message, 5000);
    };
    function getPublicidad() {

        eventoPublicidadService.getPublicidadAll().then(function (response) {

            $scope.publicidades = response.data;

        }).catch(function (err) {
            toastr.error('¡Ha ocurrido un error!', 'Error');
        });

    };
}]);