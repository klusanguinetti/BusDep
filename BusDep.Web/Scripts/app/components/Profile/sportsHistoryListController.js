app.controller('sportsHistoryListController', ['$scope', 'sportsHistoryService', 'commonService', '$http', '$rootScope', 'toastr', '$routeParams', 'Flash',
function ($scope, sportsHistoryService, commonService, $http, $rootScope, toastr, $routeParams, Flash) {

    $scope.antecedentes = {};
    $scope.perfilShort = {};
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
        var action = $routeParams.action;

        var result = $routeParams.result;

        var messageToDisplay = "";

        if (action == "add") {
            messageToDisplay = "<strong>¡Éxito!</strong> Has añadido un nuevo antecedente a tu perfil.";
        } else {
            messageToDisplay = "<strong>¡Éxito!</strong> Has editado un antecedente de tu perfil.";
        }


        if (result == "success") {
            message('success', messageToDisplay);
        }

        if (result == "notFound") {
            message('warning', '<strong>¡Hey!</strong> El antecente que buscas no esta disponible.');
        }
        commonService.getPerfilShort().then(function (response) {
            if (response.data.FechaNacimiento != null) {
                response.data.FechaNacimiento = moment(response.data.FechaNacimiento).format("DD/MM/YYYY");
            }
            $scope.perfilShort = response.data;

        }).catch(function (err) {
            toastr.error('¡Ha ocurrido un error!', 'Error');
        });
        getAntecedentes();

    });

    function message(type, message) {
        Flash.create(type, message, 5000);
    };

    function getAntecedentes() {
   
        sportsHistoryService.getAntecedentes().then(function (response) {

            $scope.antecedentes = response.data;

        }).catch(function (err) {
            toastr.error('¡Ha ocurrido un error!', 'Error');
        });

    };

    $scope.DeleteAntecedente = function (antecedenteId) {

        return sportsHistoryService.deleteAntecedente(antecedenteId).then(function (response) {

            messageToDisplay = "<strong>¡Éxito!</strong> Has eliminado un antecedente de tu perfil.";

            message('success', messageToDisplay);

            getAntecedentes();

        }).catch(function (err) {

            toastr.error('¡Error desconocido! ', 'Error');

        });

    };

}]);