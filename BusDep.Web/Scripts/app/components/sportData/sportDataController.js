app.controller('sportDataController', ['$scope', 'privateProfileService', 'commonService', '$http', '$rootScope', 'toastr', '$filter',
function ($scope, privateProfileService, commonService, $http, $rootScope, toastr, $filter) {


    $scope.Mail = $rootScope.user.UserName;

    $scope.datosPersonales = {};

    $scope.jugador = {};

    $scope.fichajes = {};
    $scope.perfiles = {};
    $scope.puestos = {};
    $scope.pies = {};
    $scope.sosVisible = true;


    $scope.modulo = 'Mis Datos Deportivos';

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


        privateProfileService.getJugador().then(function (response) {
            $scope.jugador = response.data;
        }).catch(function (err) {
            toastr.error('¡Ha ocurrido un error!', 'Error');
        });

        privateProfileService.getFichajes().then(function (response) {
            $scope.fichajes = response.data;
        }).catch(function (err) {
            toastr.error('¡Ha ocurrido un error!', 'Error');
        });

        privateProfileService.getPerfiles().then(function (response) {
            $scope.perfiles = response.data;
        }).catch(function (err) {
            toastr.error('¡Ha ocurrido un error!', 'Error');
        });

        privateProfileService.getPuestos().then(function (response) {
            $scope.puestos = response.data;
        }).catch(function (err) {
            toastr.error('¡Ha ocurrido un error!', 'Error');
        });

        privateProfileService.getPies().then(function (response) {
            $scope.pies = response.data;
        }).catch(function (err) {
            toastr.error('¡Ha ocurrido un error!', 'Error');
        });


    });


    $scope.jugadorUpdate = function () {


        return privateProfileService.jugadorUpdate($scope.jugador).then(function (response) {

            toastr.success('¡Informacion guardada con éxito!', '¡Perfecto!');

            clearErrors();

        }).catch(function (err) {

            toastr.error('¡Error desconocido!', 'Error');
        });


    };


    function clearErrors() {
        $scope.passwordForm.$setPristine();
        $scope.passwordForm.$setValidity();
        $scope.passwordForm.$setUntouched();
    }

}]);