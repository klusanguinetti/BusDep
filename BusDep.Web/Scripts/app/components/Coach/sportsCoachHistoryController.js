﻿app.controller('sportsCoachHistoryController', ['$scope', 'sportsCoachHistoryService', 'commonService', '$http', '$rootScope', 'toastr', '$filter', '$location', '$routeParams',
function ($scope, sportsCoachHistoryService, commonService, $http, $rootScope, toastr, $filter, $location, $routeParams) {


    $scope.clubes = {};
    $scope.perfilShort = {};
    $scope.antecedente = {};

    $scope.puestos = {};
    $scope.puestos1 = {};

    $scope.titulo = "";

    $scope.outcome = {
        fechaFinCheck: false
    };

    var action = "add";
    $scope.modulo = 'Antecedentes';
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

        $http.get('json/Clubes.json').then(function (data) {
            $scope.clubes = $filter('orderBy')(data.data, 'Nombre');
        });

        var antecedenteId = $routeParams.id;

        $scope.titulo = "Agregar nuevo antecedente deportivo";

       


        if (antecedenteId != null) {

            $scope.titulo = "Editar antecedente deportivo";

            action = "edit";

            return sportsCoachHistoryService.getAntecedenteById(antecedenteId).then(function (response) {

                if (response.data == "") {
                    $location.path('/History/SportsHistory/List').search({ action: action, result: 'notFound' });
                }

                $scope.antecedente = response.data;
                if (response.data.FechaFinTexto == null) {
                    $scope.outcome.fechaFinCheck = true;
                }

            }).catch(function (err) {

                toastr.error('¡Error desconocido! ', 'Error');

            });

        }


    });

    $scope.cleanInput = function () {

        $scope.antecedente.FechaFinTexto = "";

    }

    $scope.saveAntecedente = function () {

        if ($scope.antecedenteForm.$valid) {

            if ($scope.antecedente.ClubLogo != 'oo') {

                $scope.antecedente.ClubDescripcion = $filter('filter')($scope.clubes, {
                    Code: $scope.antecedente.ClubLogo
                })[0].Nombre;
            }
            return sportsCoachHistoryService.saveAntecedente($scope.antecedente).then(function (response) {

                $location.path('/Coach/SportsHistory/List').search({ action: action, result: 'success' });

            }).catch(function (err) {

                toastr.error('¡Error desconocido! ', 'Error');

            });

        }

    };

    $scope.newAntecedente = function () {

        return sportsCoachHistoryService.getNewAntecedente().then(function (response) {
            $scope.currentantecedente = response.data;
        }).catch(function (err) {

            toastr.error('¡Error desconocido!', 'Error');

        });

    };

    $scope.modifAntecedente = function (item) {

        $scope.currentantecedente = angular.copy(item);

    };


}]);