'use strict';
app.controller('indexController', ['$scope', '$location', 'commonService', 'authService', 'Carousel', '$rootScope', function ($scope, $location, commonService, authService, Carousel, $rootScope) {

    $scope.slides = [
        '/Content/img/Allwiners/jugador.png',
        '/Content/img/Allwiners/entrenadores.png',
        '/Content/img/Allwiners/agentes.png',
        '/Content/img/Allwiners/clubes.png'
    ]
    $scope.searchResult = {};


    angular.element(function () {

        commonService.getTopJugador().then(function (response) {

            $scope.searchResult = response.data;

        }).catch(function (err) {
            toastr.error('¡Ha ocurrido un error!', 'Error');
        });

        

    });

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