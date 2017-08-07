﻿app.controller('sportsHistoryController', ['$scope', 'sportsHistoryService', '$http', '$rootScope', 'toastr','$filter','$location','$routeParams',
function ($scope, sportsHistoryService, $http, $rootScope, toastr, $filter, $location, $routeParams) {


    $scope.clubes = {};

    $scope.antecedente = {};

    $scope.outcome = {
        fechaFinCheck: false
    };

    angular.element(function () {

        var antecedenteId = $routeParams.id;

        if (antecedenteId != null) {

            return sportsHistoryService.getAntecedenteById(antecedenteId).then(function (response) {

              

            }).catch(function (err) {

                toastr.error('¡Error desconocido! ', 'Error');

            });

        } 

        $http.get('json/Clubes.json').then(function (data) {
            $scope.clubes = data.data;
        });

    });

    $scope.cleanInput = function () {

        $scope.antecedente.FechaFin = "";

    }

    $scope.saveAntecedente = function () {

        if ($scope.antecedenteForm.$valid) {

            $scope.antecedente.ClubDescripcion = $filter('filter')($scope.clubes, { Code: $scope.antecedente.ClubLogo })[0].Nombre;

            return sportsHistoryService.saveAntecedente($scope.antecedente).then(function (response) {

                $location.path('/History/SportsHistory/List').search({result: 'success'});

            }).catch(function (err) {

                toastr.error('¡Error desconocido! ', 'Error');

            });

        }

    };

    $scope.newAntecedente = function () {

        return sportsHistoryService.getNewAntecedente().then(function (response) {
            $scope.currentantecedente = response.data;
        }).catch(function (err) {

            toastr.error('¡Error desconocido!', 'Error');

        });

    };

    $scope.modifAntecedente = function (item) {


        $scope.currentantecedente = angular.copy(item);

        $scope.currentantecedente.FechaInicio = moment($scope.currentantecedente.FechaInicio).format("DD/MM/YYYY");


        if (item.FechaFin != null) {
            $scope.currentantecedente.FechaFin = moment($scope.currentantecedente.FechaFin).format("DD/MM/YYYY");
        }
    };


}]);