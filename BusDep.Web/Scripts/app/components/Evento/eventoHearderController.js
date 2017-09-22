'use strict';
app.controller('eventoHearderController', ['$scope', '$window', 'eventoPublicidadService',
function ($scope, $window,  eventoPublicidadService) {
    $scope.hideevento = true;

    angular.element(function () {
        if($scope.user.authenticated)
        {
            eventoPublicidadService.getEventoPublicidadActivaCount($scope.user).then(function (response) {
                $scope.hideevento = response.data==0;
            }).catch(function (err) {

                $scope.hideevento = false;

            });
        }
    });
}]);