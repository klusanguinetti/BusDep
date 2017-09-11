'use strict';
app.service('commonService', ['$http', '$q', function ($http, $q) {

    var serviceBase = '/api/Base/';

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

        var deferred = $q.defer();

        $http.post(serviceBase + 'GetMenu').then(function (response) {

            deferred.resolve(response);

        }).catch(function (err) {
            deferred.reject(err);
        });

        return deferred.promise;


        //return $http.post(serviceBase + 'GetMenu').then(function (response) {
        //    return response;
        //});

    };

}]);