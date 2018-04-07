'use strict';
app.controller('searchJugadorController', ['$scope', '$window', '$filter', '$location', 'searchJugadorService', 'commonService', 'authService', '$rootScope', 'toastr', '$routeParams', 'Flash',
function ($scope, $window, $filter, $location, searchJugadorService, commonService, authService, $rootScope, toastr, $routeParams, Flash) {
    $scope.searchResult = [];
    $scope.searchFiltro = [];
    $scope.modulo = 'Busqueda de Jugadores';
    $scope.Busqueda = 'T';
    $scope.filtro = '';

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
        getJugadores();

    });

    
    function getJugadores() {

        searchJugadorService.getJugadoresAll().then(function (response) {

            $scope.searchResult = response.data;
            $scope.searchFiltro = $scope.searchResult;

        }).catch(function (err) {
            toastr.error('¡Ha ocurrido un error!', 'Error');
        });

    };
   
    $scope.filter = (function (input) {
        if ($scope.Busqueda == 'T') {
            $scope.searchFiltro = $scope.searchResult;  
        }
        else if ($scope.Busqueda == 'C') {
            $scope.searchFiltro = $filter('filter')($scope.searchResult, { PerfilCompleto:true });
        } else {
            $scope.searchFiltro = $filter('filter')($scope.searchResult, { PerfilCompleto: false });
        }
    });


}]);