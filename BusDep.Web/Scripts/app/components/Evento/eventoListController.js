'use strict';
app.controller('eventoListController', ['$scope', '$window', 'eventoPublicidadService', 'commonService', 'authService', '$rootScope', 'toastr',  
function ($scope, $window,  eventoPublicidadService, commonService, authService, $rootScope, toastr) {
    $scope.eventos = [];

    $scope.modulo = 'Eventos';
    $scope.moduloicono = 'fa fa-heart';
    

    

    angular.element(function () {
        commonService.getMenu().then(function (response) {
            $rootScope.user.menu = response.data;
            angular.forEach($rootScope.user.menu, function (value, key) {
                if (value.Descripcion == $scope.modulo) {
                    $scope.moduloicono = value.Icono;
                }
            });
            search();

        }).catch(function (err) {
            toastr.error('¡Ha ocurrido un error!', 'Error');
        });
    });
    $scope.search = (function () {
        search();
    });

    function search() {
        $scope.myPromise = eventoPublicidadService.getEventoPublicidadActivaAll($scope.user).then(function (response) {

            $scope.eventos = response.data;

        }).catch(function (err) {

            toastr.error('¡Ha ocurrido un error! ' + err, 'Error');

        });
        
    }

    $scope.abrirlink = (function (item) {
        $window.open(item.Link, '_blank');
    });
}]);