app.controller('sportsHistoryController', ['$scope', 'sportsHistoryService', 'commonService', '$http', '$rootScope', 'toastr', '$filter', '$location', '$routeParams',
function ($scope, sportsHistoryService, commonService, $http, $rootScope, toastr, $filter, $location, $routeParams) {


    $scope.clubes = {};
    $scope.perfilShort = {};
    $scope.antecedente = {};

    $scope.puestos = {};
    $scope.puestos1 = {};

    $scope.titulo = "";

    $scope.outcome = {
        fechaFinCheck: false
    };

    var action = "add";
    $scope.modulo = 'Antecedentes';
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

        $http.get('json/Clubes.json').then(function (data) {
            $scope.clubes = $filter('orderBy')(data.data, 'Nombre');
        });

        commonService.getPerfilJugadorShort().then(function (response) {
            if (response.data.FechaNacimiento != null) {
                response.data.FechaNacimiento = moment(response.data.FechaNacimiento).format("DD/MM/YYYY");
            }
            $scope.perfilShort = response.data;

        }).catch(function (err) {
            toastr.error('¡Ha ocurrido un error!', 'Error');
        });

        var antecedenteId = $routeParams.id;

        $scope.titulo = "Agregar nuevo antecedente deportivo";

        sportsHistoryService.getPuestosCode().then(function (response) {
            $scope.puestos = response.data;
            $scope.puestos1 = response.data;
        }).catch(function (err) {
            toastr.error('¡Ha ocurrido un error!', 'Error');
        });


        if (antecedenteId != null) {

            $scope.titulo = "Editar antecedente deportivo";

            action = "edit";

            return sportsHistoryService.getAntecedenteById(antecedenteId).then(function (response) {

                if (response.data == "") {
                    $location.path('/History/SportsHistory/List').search({ action: action, result: 'notFound' });
                }

                $scope.antecedente = response.data;

                var FechaInicio = moment(response.data.FechaInicio).format("DD/MM/YYYY");

                $scope.antecedente.FechaInicio = FechaInicio;

                if (response.data.FechaFin != null) {

                    var FechaFin = moment(response.data.FechaFin).format("DD/MM/YYYY");

                    $scope.antecedente.FechaFin = FechaFin;

                } else {
                    $scope.outcome.fechaFinCheck = true;
                }

            }).catch(function (err) {

                toastr.error('¡Error desconocido! ', 'Error');

            });

        }


    });

    $scope.cleanInput = function () {

        $scope.antecedente.FechaFin = "";

    }

    $scope.saveAntecedente = function () {

        if ($scope.antecedenteForm.$valid) {

            if ($scope.antecedente.ClubLogo != 'oo') {

                $scope.antecedente.ClubDescripcion = $filter('filter')($scope.clubes, {
                    Code: $scope.antecedente.ClubLogo
                })[0].Nombre;
            }
            return sportsHistoryService.saveAntecedente($scope.antecedente).then(function (response) {

                $location.path('/History/SportsHistory/List').search({ action: action, result: 'success' });

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