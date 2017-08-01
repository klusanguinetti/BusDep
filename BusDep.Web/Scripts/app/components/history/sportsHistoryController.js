app.controller('sportsHistoryController', ['$scope', 'sportsHistoryService', '$http', '$rootScope', 'toastr',
function ($scope, sportsHistoryService, $http, $rootScope, toastr) {

    $scope.clubes = {};

    $scope.antecedentes = {};

    $scope.currentantecedente = null;

    $scope.jugador = {};
    $scope.popuphide = false;

    angular.element(function () {
        sportsHistoryService.getJugador().then(function (response) {
            $scope.jugador = response.data;
        }).catch(function (err) {
            toastr.error('¡Ha ocurrido un error!', 'Error');
        });
        sportsHistoryService.getAntecedentes().then(function (response) {
            $scope.antecedentes = response.data;
        }).catch(function (err) {
            toastr.error('¡Ha ocurrido un error!', 'Error');
        });
        sportsHistoryService.getClubes().then(function (response) {
            $scope.clubes = response.data;
        }).catch(function (err) {
            toastr.error('¡Ha ocurrido un error!', 'Error');
        });

    });

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

    $scope.saveAntecedente = function () {
        return sportsHistoryService.saveAntecedente($scope.currentantecedente).then(function (response) {
            $scope.antecedentes = response.data;
            toastr.success('Se guardo correctamente', 'Ok');
        }).catch(function (err) {

            toastr.error('¡Error desconocido! ', 'Error');

        });

    };

}]);