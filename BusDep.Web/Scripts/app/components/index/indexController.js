'use strict';
app.controller('indexController', ['$scope', '$location', 'authService', 'Carousel', '$rootScope', function ($scope, $location, authService, Carousel, $rootScope) {

    $scope.slides = [
        '/Content/img/Allwiners/baner_jugador.png',
        '/Content/img/Allwiners/banner_club.png',
        '/Content/img/Allwiners/banner_intemediarios.png',
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

        $location.path("/Search").search({ b: $scope.searchValue});

    }



}]);