app.controller('sportsHistoryController', ['$scope', 'sportsHistoryService', '$http', '$rootScope', 'toastr','$filter','$location',
function ($scope, sportsHistoryService, $http, $rootScope, toastr, $filter, $location) {


    $scope.clubes = {};

    $scope.antecedente = {};

    angular.element(function () {

        $http.get('json/Clubes.json').then(function (data) {
            $scope.clubes = data.data;
            console.log($scope.clubes);
        });

    });

    $scope.saveAntecedente = function () {

        $scope.antecedente.ClubDescripcion = $filter('filter')($scope.clubes, { Nombre: $scope.antecedente.ClubLogo })[0].Nombre;

        return sportsHistoryService.saveAntecedente($scope.antecedente).then(function (response) {

            $location.path('/History/SportsHistory/List');

        }).catch(function (err) {

            toastr.error('¡Error desconocido! ', 'Error');

        });

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