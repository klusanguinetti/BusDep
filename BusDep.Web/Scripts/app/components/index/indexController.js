'use strict';
app.controller('indexController', ['$scope', '$location', 'authService', 'Carousel', '$rootScope', function ($scope, $location, authService, Carousel, $rootScope) {

    $scope.slides= [
      'http://lorempixel.com/1600/400/sports/1',
      'http://lorempixel.com/1600/400/sports/2',
      'http://lorempixel.com/1600/400/sports/3',
    ]

    $(function () {
        $('.row-featured .f-category').matchHeight();
        $.fn.matchHeight._apply('.row-featured .f-category');
    });

    $scope.authentication = authService.authentication;

    /*Declaración de funciones*/

    $scope.logOut = function () {

        authService.logOut().then(function (response) {

            $location.path('/home');

        }).catch(function (err) {

            console.log("Ha ocurrido un error al cerrar sesión: " + err)

        });

    }

    $scope.search = function () {

        /*Sanitaze this input*/

        $location.path("/Search").search({ b: $scope.searchValue});;

    }



}]);