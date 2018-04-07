app.controller('selfAppraisalController', ['$scope', 'selfAppraisalService', 'commonService', '$http', '$rootScope', 'toastr',
    function ($scope, selfAppraisalService, commonService, $http, $rootScope, toastr) {

        $scope.perfilShort = {};
        $scope.autoEvaluacion = {};

        $scope.jugador = {};

        $scope.puntuacion = [{ "Valor": 1 }, { "Valor": 2 }, { "Valor": 3 }, { "Valor": 4 }, { "Valor": 5 }];

        $scope.modulo = 'AutoEvaluación';
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

            $scope.myPromise = selfAppraisalService.getAutoEvaluacion().then(function (response) {

                $scope.autoEvaluacion = response.data;

            }).catch(function (err) {
                toastr.error('¡Ha ocurrido un error!', 'Error');
            });

        });

        $scope.save = function () {

            return selfAppraisalService.save($scope.autoEvaluacion).then(function (response) {

                $scope.antecedentes = response.data;

                toastr.success('Se guardo correctamente', 'Ok');

            }).catch(function (err) {

                toastr.error('¡Error desconocido! ', 'Error');

            });

        };

    }]);