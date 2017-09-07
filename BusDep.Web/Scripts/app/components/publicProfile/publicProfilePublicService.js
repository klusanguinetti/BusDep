'use strict';
app.service('publicProfilePublicService', ['$http', '$q', function ($http, $q) {

    var serviceBase = '/ProfilePublic/';

    this.getPublicProfile = function (jugadorId) {

        var deferred = $q.defer();

        $http.get(serviceBase + 'GetPublicProfile?jugadorId=' + jugadorId).then(function (response) {

            deferred.resolve(response);

        }).catch(function (err) {

            deferred.reject(err);

        });

        return deferred.promise;

    };
    this.getAutoEvaluacion = function (jugadorId) {

        var deferred = $q.defer();

        $http.get(serviceBase + 'GetAutoEvaluacionDefault?jugadorId=' + jugadorId).then(function (response) {

            deferred.resolve(response);

        }).catch(function (err) {

            deferred.reject(err);

        });

        return deferred.promise;

    };

    this.getAntecedentes = function (jugadorId) {

        var deferred = $q.defer();

        $http.get(serviceBase + 'GetAntecedentes?jugadorId=' + jugadorId).then(function (response) {

            deferred.resolve(response);

        }).catch(function (err) {

            deferred.reject(err);

        });

        return deferred.promise;

    };

}]);