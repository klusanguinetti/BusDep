app.controller('sportsHistoryListController', ['$scope', 'sportsHistoryService', '$http', '$rootScope', 'toastr',
function ($scope, sportsHistoryService, $http, $rootScope, toastr) {

    $scope.antecedentes = {};

    angular.element(function () {

        sportsHistoryService.getAntecedentes().then(function (response) {
            $scope.antecedentes = response.data;
            console.log(response.data);
        }).catch(function (err) {
            toastr.error('¡Ha ocurrido un error!', 'Error');
        });

    });


}]);