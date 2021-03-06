﻿'use strict';
app.controller('indexController', ['$scope', '$window', '$location', 'commonService', 'authService', '$rootScope', 'toastr',
function ($scope, $window, $location, commonService, authService, $rootScope, toastr) {

    $scope.myInterval = 3000;

    $scope.slides = [
      {
          image: '/Content/img/Allwiners/jugador.jpg'
      },
      {
          image: '/Content/img/Allwiners/entrenadores.jpg'
      },
      {
          image: '/Content/img/Allwiners/agentes.jpg'
      },
      {
          image: '/Content/img/Allwiners/clubes.jpg'
      }
    ];


    $scope.slidespublicidad = [
     {
         image: '/Content/img/Allwiners/jugador.jpg'
     },
     {
         image: '/Content/img/Allwiners/entrenadores.jpg'
     },
     {
         image: '/Content/img/Allwiners/agentes.jpg'
     },
     {
         image: '/Content/img/Allwiners/clubes.jpg'
     }
    ];
    $scope.slidespublicidadchica = [
     {
         image: '/Content/img/misc/Pruebas0.jpg'
     },
     {
         image: '/Content/img/misc/Pruebas1.jpg'
     },
     {
         image: '/Content/img/misc/Pruebas2.jpg'
     },
     {
         image: '/Content/img/misc/Pruebas3.jpg'
     },
     {
         image: '/Content/img/misc/Pruebas4.jpg'
     },
     {
         image: '/Content/img/misc/Pruebas5.jpg'
     }
    ];

    $scope.searchResult = {};

    $scope.picFile = "https://allwiners.blob.core.windows.net/photos/default_avatar-thumb.jpg";

    angular.element(function () {

        commonService.getMenu().then(function (response) {

            $rootScope.user.menu = response.data;

        }).catch(function (err) {
            toastr.error('¡Ha ocurrido un error!', 'Error');
        });

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

        $location.path("/Search").search({ b: $scope.searchValue });

    }

    $scope.abrirlink = (function (item) {
        $window.open(item.Link, '_blank');
    });

}]);