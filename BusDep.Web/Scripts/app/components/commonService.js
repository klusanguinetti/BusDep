'use strict';
app.service('commonService', ['$http', '$q', function ($http, $q) {

    var serviceBase = '/Base/';

    this.getPerfilJugadorShort = function () {

        return $http.post(serviceBase + 'GetPerfilJugadorShort').then(function (response) {
            return response;
        });

    };
    this.getTopJugador = function () {

        return $http.post(serviceBase + 'TopJugador').then(function (response) {
            return response;
        });

    };

    this.getMenu = function () {

        return $http.post(serviceBase + 'GetMenu').then(function (response) {
            return response;
        });

    };

}]);