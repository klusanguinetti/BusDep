app.controller('sportsHistoryController', ['$scope', 'sportsHistoryService', '$http', '$rootScope', 'toastr',
function ($scope, sportsHistoryService, $http, $rootScope, toastr) {

    $scope.clubes = {};

    $scope.antecedentes = {};

    $scope.currentantecedente = null;

    $scope.jugador = {};
    $scope.popuphide = function () {
        return $scope.currentantecedente == null;
    };
    
   

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

    $scope.modifAntecedente = function (id) {
        
        if ($scope.currentantecedente != null) {
            
        }
        var select = antecedentes.filter(function (item) {
            return item.id === id;
        })[0];

        if (select != null && select != undefined) {
            $scope.currentantecedente = select;
        }
    };

    $scope.saveAntecedente = function (item) {

        return sportsHistoryService.saveAntecedente(item).then(function (response) {
            $scope.antecedentes = response.data;
            $scope.currentantecedente = null;
            toastr.success('Se guardo correctamente', 'Ok');
        }).catch(function (err) {

            toastr.error('¡Error desconocido!', 'Error');

        });

    };

}]);