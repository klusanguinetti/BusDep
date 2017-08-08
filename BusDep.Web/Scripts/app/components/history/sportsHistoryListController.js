app.controller('sportsHistoryListController', ['$scope', 'sportsHistoryService', '$http', '$rootScope', 'toastr', '$routeParams', 'Flash',
function ($scope, sportsHistoryService, $http, $rootScope, toastr, $routeParams, Flash) {

    $scope.antecedentes = {};

    angular.element(function () {

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