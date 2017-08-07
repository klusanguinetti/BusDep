app.controller('sportsHistoryListController', ['$scope', 'sportsHistoryService', '$http', '$rootScope', 'toastr','$routeParams','Flash',
function ($scope, sportsHistoryService, $http, $rootScope, toastr, $routeParams, Flash) {

    $scope.antecedentes = {};

    angular.element(function () {

        var result = $routeParams.result;

        if (result == "success") {
            success();
        }

        sportsHistoryService.getAntecedentes().then(function (response) {

            $scope.antecedentes = response.data;
            console.log(response.data);

        }).catch(function (err) {
            toastr.error('¡Ha ocurrido un error!', 'Error');
        });

    });

    function success() {
        var message = '<strong>¡Éxito!</strong> Has añadido un nuevo antecedente a tu perfil.';
        Flash.create('success', message,0);
    };

}]);