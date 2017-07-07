'use strict';
app.controller('indexController', ['$scope', '$location', 'authService', function ($scope, $location, authService) {

    $scope.logOut = function () {
        authService.logOut();
        $location.path('/home');
    }

    $scope.authentication = authService.authentication;

    $scope.search = function () {

        $location.path("/Search");

    }

    $(function () {
        $('.row-featured .f-category').matchHeight();
        $.fn.matchHeight._apply('.row-featured .f-category');
    });

}]);