'use strict';
app.service('publicProfileService', ['$http', '$q', function ($http, $q) {

    //var serviceBase = '/api/Profile/';
    var serviceBase = '/Profile/';

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

    this.getRecomendaciones = function (jugadorId) {

        var deferred = $q.defer();

        $http.get(serviceBase + 'GetRecomendaciones?jugadorId=' + jugadorId).then(function (response) {

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