'use strict';
app.controller('indexController', ['$scope', '$location', 'authService', 'Carousel', function ($scope, $location, authService, Carousel) {

    $scope.slides= [
      'http://lorempixel.com/1600/400/sports/1',
      'http://lorempixel.com/1600/400/sports/2',
      'http://lorempixel.com/1600/400/sports/3',
    ]

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