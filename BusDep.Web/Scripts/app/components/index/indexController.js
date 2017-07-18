'use strict';
app.controller('indexController', ['$scope', '$location', 'authService', 'Carousel', '$rootScope', function ($scope, $location, authService, Carousel, $rootScope) {

    $scope.slides= [
      'http://lorempixel.com/1600/400/sports/1',
      'http://lorempixel.com/1600/400/sports/2',
      'http://lorempixel.com/1600/400/sports/3',
    ]

    $scope.logOut = function () {

        authService.logOut().then(function (response) {

            $location.path('/home');

        }).catch(function (err) {

            console.log("Ha ocurrido un error al cerrar sesión: " + err)

        });

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